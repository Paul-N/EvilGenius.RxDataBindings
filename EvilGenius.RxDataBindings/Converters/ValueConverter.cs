using System;
using System.Globalization;

namespace EvilGenius.RxDataBindings.Converters;

public abstract class ValueConverter : IValueConverter
{
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
}

public abstract class ValueConverter<TFrom, TTo> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Convert((TFrom)value, targetType, parameter, culture);

    protected virtual TTo Convert(TFrom value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ConvertBack((TTo)value, targetType, parameter, culture);

    protected virtual TFrom ConvertBack(TTo value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public abstract class ValueConverter<TFrom> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Convert((TFrom)value, targetType, parameter, culture);

    protected virtual object Convert(TFrom value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => TypedConvertBack(value, targetType, parameter, culture);

    protected virtual TFrom TypedConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
