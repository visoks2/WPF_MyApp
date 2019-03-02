using CsvHelper;
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
        public static void LoadData<T>(this ObservableCollection<T> entity)
            where T : BaseEntity
        {
            if (App.IsDesignMode)
                return;
            string path = entity.GetPath();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                //csv.Configuration.HasHeaderRecord = false;
                entity.Clear();

                IEnumerable<T> records = csv.GetRecords<T>();
                foreach (T record in records)
                {
                    entity.Add(record);
                }

            }
        }

        public static void SaveData<T>(this ObservableCollection<T> entity)
        where T : BaseEntity
        {
            if (App.IsDesignMode)
                return;

            string path = entity.GetPath();

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(entity);
            }
        }
        private static string GetPath<T>(this ObservableCollection<T> entity)
            where T : BaseEntity
        {
            DataLocationAttribute attribute = (DataLocationAttribute)typeof(T).GetCustomAttributes(typeof(DataLocationAttribute), false).FirstOrDefault();
            return attribute != null ? attribute.FileName : typeof(T).Name;
        }
    }
}
