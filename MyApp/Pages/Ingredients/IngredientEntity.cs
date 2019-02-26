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
    public class IngredientEntity
    {
        private int _id;
        private string _name;
        private string _description;
        private int _price;
        private int _quantityLeft;
        private List<IngredientEntity> myVar = new List<IngredientEntity>();

        public int ID {
            get { return _id; }
            set { _id = value; }
        }

        [DisplayName("Pavadinimas")]
        public string Name {
            get { return _description; }
            set { _description = value; }
        }

        [DisplayName("Aprašas")]
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        [DisplayName("Kaina")]
        public int Price {
            get { return _price; }
            set { _price = value; }
        }

        [DisplayName("Likęs kiekis")]
        public int QuantityLeft {
            get { return _quantityLeft; }
            set { _quantityLeft = value; }
        }

        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<IngredientEntity> MyProperty {
            get {
                if (myVar.Count == 0)
                {
                    myVar.Add(this);
                    myVar.Add(new IngredientEntity());

                }
                return myVar; }
            set { myVar = value; }
        }

    }
}
