using MyApp.Pages.Ingredients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyApp.Converters
{
    public class DuplicateValueToColorConverter : IMultiValueConverter//IValueConverter
    {
        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    ObservableCollection<IngredientEntity> ingredients = value as ObservableCollection<IngredientEntity>;
        //    if (ingredients == null)
        //        return false;

        //    var totalResult = ingredients.Take(ingredients.Count - 1);
        //    var lastItem = ingredients.LastOrDefault();
        //    foreach (var item in totalResult)
        //    {
        //        if (item.Name.Equals(lastItem.Name))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;

        //}
        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<IngredientEntity> ingredients = values[0] as ObservableCollection<IngredientEntity>;
            //IngredientEntity selectedItem = values[1] as IngredientEntity;
            IngredientEntity currentItem = values[2] as IngredientEntity;
            if (ingredients == null /*|| selectedItem == null*/ || currentItem == null)
                return false;
            
            return ingredients.Count(e => e.Name == currentItem.Name) > 1;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
