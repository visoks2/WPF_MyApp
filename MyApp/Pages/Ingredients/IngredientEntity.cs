using CsvHelper.Configuration;
using MyApp.DataProvider;
using MyApp.Pages.Products;

namespace MyApp.Pages.Ingredients
{
    [DataLocation("base_ingredients.csv")]
    public class IngredientEntity : BaseEntity
    {
        private string _name;
        private string _description;
        private string _category;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        public string Category {
            get { return _category; }
            set { _category = value; }
        }

    }

    public class IngredientEntityMap : ClassMap<ProductsEntity>
    {
        public IngredientEntityMap()
        {
            Map(m => m.Name);
            Map(m => m.Description);
            Map(m => m.Category);
        }
    }
}
