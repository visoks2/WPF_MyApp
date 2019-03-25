using CsvHelper;
using MyApp.DataProvider;
using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.Pages.Products
{
    public class ProductsViewModel : BaseViewModel
    {
        public ICommand SaveComand { get; }
        public ICommand RefreshComand { get; }
        public ICommand DeleteComand { get; }
        public ICommand AddNewItemCommand { get; }

        private ObservableCollection<ProductsEntity> _products = new ObservableCollection<ProductsEntity>();
        private ProductsEntity _selectedItem;
        private bool _isSelectedItemValid;

        public ProductsViewModel()
        {
            SaveComand = new AnotherCommandImplementation(_ => Save());
            RefreshComand = new AnotherCommandImplementation(_ => Refresh());
            DeleteComand = new AnotherCommandImplementation(_ => Delete());
            AddNewItemCommand = new AnotherCommandImplementation(_ => AddNewItem());
        }

        public ObservableCollection<ProductsEntity> Products {
            get { return _products; }
            set { _products = value; }
        }
        public ProductsEntity SelectedItem {
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public bool IsSelectedItemValid {
            get { return _isSelectedItemValid; }
            set {
                _isSelectedItemValid = value;
                OnPropertyChanged();
            }
        }

        private void Save()
        {
            Products[0].Category = "dfsdfs";
            Products[0].IngredientsList.Add(new Ingredients.IngredientEntity() { Name = "test", Description = "somecat", Category = "none" });
            //Products.SaveData();
        }
        private void Refresh()
        {
            Products.LoadData();
        }
        private void Delete()
        {
            Products.Remove(SelectedItem);
        }
        public void AddNewItem()
        {
            ProductsEntity newItem = new ProductsEntity();
            Products.Add(newItem);
            SelectedItem = newItem;
        }
    }
}
