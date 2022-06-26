using System;
using System.Globalization;
using EvilGenius.RxDataBindings.Converters;

namespace RxMvvmDemo.Core
{
    public class BoolInvertedConverter : ValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture) => !value;

        protected override bool ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture) => !value;
    }
}
