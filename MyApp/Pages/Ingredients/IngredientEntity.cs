using CsvHelper.Configuration.Attributes;
using MyApp.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Pages.Ingredients
{
    [DataLocation("base_ingredients.csv")]
    public class IngredientEntity : BaseEntity
    {
        private string _name;
        private string _description;
        private string _category;

        [Index(0)]
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        [Index(1)]
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        [Index(2)]
        public string Category {
            get { return _category; }
            set { _category = value; }
        }

    }
}
