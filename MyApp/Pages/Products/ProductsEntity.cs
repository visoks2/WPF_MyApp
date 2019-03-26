using CsvHelper.Configuration;
using MyApp.DataProvider;
using MyApp.Pages.Ingredients;
using System.Collections.ObjectModel;

namespace MyApp.Pages.Products
{
    [DataLocation("products.csv")]
    public class ProductsEntity : IngredientEntity
    {
        private string _ingredients = string.Empty;
        private ObservableCollection<IngredientEntity> _ingredientsList = new ObservableCollection<IngredientEntity>();

        public string Ingredients {
            get {
                OnIngredientsCountChanged();
                return _ingredients;
            }
            set {
                _ingredients = value;
            }
        }

        public ObservableCollection<IngredientEntity> IngredientsList {
            get { return _ingredientsList; }
            set {
                _ingredientsList = value;
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

    public class ProductsEntityMap : ClassMap<ProductsEntity>
    {
        public ProductsEntityMap()
        {
            Map(m => m.Name);
            Map(m => m.Description);
            Map(m => m.Category);
            Map(m => m.IngredientsList).TypeConverter<JsonConverter<ObservableCollection<IngredientEntity>>>();
            Map(m => m.Ingredients).Ignore();
        }
    }
}
