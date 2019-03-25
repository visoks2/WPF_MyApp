using CsvHelper.Configuration.Attributes;
using MyApp.DataProvider;
using MyApp.Pages.Ingredients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Pages.Products
{
    [DataLocation("products.csv")]
    public class ProductsEntity : IngredientEntity
    {
        private string _ingredients = string.Empty;
        private ObservableCollection<IngredientEntity> _ingredientsList = new ObservableCollection<IngredientEntity>();


        [Ignore]
        public string Ingredients {
            get {
                OnIngredientsCountChanged();
                return _ingredients; }
            set { _ingredients = value;
            }
        }

        [Index(3)]
        public ObservableCollection<IngredientEntity> IngredientsList {
            get { return _ingredientsList; }
            set { _ingredientsList = value;
                OnIngredientsCountChanged();
            }
        }


        private void OnIngredientsCountChanged()
        {
            switch (_ingredientsList.Count)
            {
                case 0:
                    Ingredients = "nk nera";
                    break;
                case 1:
                    Ingredients = "1 ingredientas";
                    break;
                default:
                    Ingredients = _ingredientsList.Count.ToString() + (_ingredientsList.Count < 10 ? " ingredientai" : " ingredientu");
                    break;
            }
        }
    }
}
