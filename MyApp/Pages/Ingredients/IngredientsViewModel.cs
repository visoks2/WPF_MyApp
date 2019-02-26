using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Pages.Ingredients
{
    public class IngredientsViewModel
    {
        private List<IngredientEntity> _ingredients = new List<IngredientEntity>();
        public IngredientsViewModel()
        {
            _ingredients.Add(new IngredientEntity() {ID = 0, Name = "asd", Description = "test"});
        }

        public List<IngredientEntity> Ingredients {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

    }
}
