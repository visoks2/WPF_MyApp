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

namespace MyApp.Pages.Ingredients
{
    public class IngredientsViewModel : BaseViewModel
    {
        public ICommand SaveComand { get; }
        public ICommand RefreshComand { get; }
        public ICommand DeleteComand { get; }
        public ICommand AddNewItemCommand { get; }

        private ObservableCollection<IngredientEntity> _ingredients = new ObservableCollection<IngredientEntity>();
        private IngredientEntity _selectedItem;

        public IngredientsViewModel()
        {
            SaveComand = new AnotherCommandImplementation(_ => Save());
            RefreshComand = new AnotherCommandImplementation(_ => Refresh());
            DeleteComand = new AnotherCommandImplementation(_ => Delete());
            AddNewItemCommand = new AnotherCommandImplementation(_ => AddNewItem());
        }
        
        public ObservableCollection<IngredientEntity> Ingredients {
            get { return _ingredients; }
            set {
                _ingredients = value;
                //OnPropertyChanged("Ingredients");
            }
        }

        public IngredientEntity SelectedItem {
            get { return _selectedItem; }
            set { _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void Save()
        {
            Ingredients.SaveData();
        }

        private void Refresh()
        {
            Ingredients.LoadData();
        }

        private void Delete()
        {
            Ingredients.Remove(SelectedItem);
        }

        public void AddNewItem()
        {
            IngredientEntity newItem = new IngredientEntity();
            Ingredients.Add(newItem);

            SelectedItem = newItem;
        }
    }
}
