using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI;


namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            
                if (value is bool) return (bool)value ? TrueColor : FalseColor;
                return FalseColor;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = default(bool);
            if (value is Color)
            {
                if ((Color)value == TrueColor) { returnValue = false; }
                else if ((Color)value == FalseColor) { returnValue = true; }
            }
            return returnValue;
        }
    }
}
