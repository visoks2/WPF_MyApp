using CsvHelper;
using CsvHelper.Configuration;
using MyApp.Pages.Ingredients;
using MyApp.Pages.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataProvider
{
    public static class BaseDataProvider
    {
        delegate ClassMap RegMap(Type classMapType);
        #region Public
        public static void LoadData<T>(this ObservableCollection<T> entity)
            where T : BaseEntity
        {
            if (App.IsDesignMode)
                return;
            string path = entity.GetPath();
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (!fileInfo.Exists)
                {
                    SaveData(entity);
                }

                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader))
                {
                    RegisterMap(csv.Configuration.RegisterClassMap, entity.GetType());
                    csv.Configuration.HasHeaderRecord = true;
                    entity.Clear();
                    IEnumerable<T> records = csv.GetRecords<T>();
                    foreach (T record in records)
                    {
                        entity.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static void SaveData<T>(this ObservableCollection<T> entity) where T : BaseEntity
        {
            if (App.IsDesignMode)
                return;

            string path = entity.GetPath();
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                RegisterMap(csv.Configuration.RegisterClassMap, entity.GetType());
                csv.Configuration.HasHeaderRecord = true;
                csv.WriteRecords(entity);
            }
        }
        #endregion

        #region Private 
        private static string GetPath<T>(this ObservableCollection<T> entity)
            where T : BaseEntity
        {
            DataLocationAttribute attribute = (DataLocationAttribute)typeof(T).GetCustomAttributes(typeof(DataLocationAttribute), false).FirstOrDefault();
            return attribute != null ? attribute.FileName : typeof(T).Name;
        }
        private static void RegisterMap(RegMap register, Type type)
        {
            if (type == typeof(ObservableCollection<ProductsEntity>))
            {
                register(typeof(ProductsEntityMap));
            }
            else if (type == typeof(ObservableCollection<IngredientEntityMap>))
            {
                register(typeof(IngredientEntityMap));
            }
            else
            {
                
            }
        }
        #endregion

    }
}
