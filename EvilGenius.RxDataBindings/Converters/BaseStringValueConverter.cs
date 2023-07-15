using System;
using System.Globalization;

namespace EvilGenius.RxDataBindings.Converters;

public class BaseStringValueConverter<TFrom> : ValueConverter<TFrom, string>
{
    protected override string Convert(TFrom value, Type targetType, object parameter, CultureInfo culture) => value == null ? null : value.ToString();
}
