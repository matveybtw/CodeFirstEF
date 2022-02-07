using CodeFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace CodeFirstEF
{
    [ValueConversion(typeof(Category), typeof(Color))]
    public class CategoryToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = value as Category;
            if (c.Type=="Rate")
            {
                return Color.Red;
            }
            else
            {
                return Color.Green;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = value as Color;
            if (c==Color.Red)
            {
                using (var ctx = new CodeFirstEFContext())
                {
                    return ctx.Categories.First(o => o.Id == 2);
                }
            }
            else
            {
                using (var ctx = new CodeFirstEFContext())
                {
                    return ctx.Categories.First(o => o.Id == 1);
                }
            }
        }
    }
}
