using System;
using System.Globalization;
using EvilGenius.RxDataBindings.Converters;

namespace RxMvvmDemo.Core
{
    public class StringConverter : IValueConverter//<object, string>
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public /*protected override*/ object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"{parameter} {value}";
    }
}
