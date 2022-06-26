using EvilGenius.RxDataBindings.Converters;
using EvilGenius.RxDataBindings.Properties;
using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using System;
using System.Globalization;

namespace EvilGenius.RxDataBindings.Bindings
{
    public class RxBinding<TTargetProperty, TSourceProperty> : RxBindingBase<TSourceProperty, TTargetProperty>
    {
        

        public RxBinding(ITargetProxy targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
             : base(targetProxy, sourceProperty, mode, converter, converterParam)
            => SetupConverter(mode, converter, converterParam);

        public RxBinding(ITargetProxy targetProxy, IPropertySetterProxy<TSourceProperty> sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
             : base(targetProxy, sourceProperty, mode, converter, converterParam) 
            => SetupConverter(mode, converter, converterParam);

        public RxBinding(IPropertySetterProxy<TTargetProperty> targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
             : base(targetProxy, sourceProperty, mode, converter, converterParam)
            => SetupConverter(mode, converter, converterParam);

        protected override void SetupConverter(BindingMode mode, IValueConverter converter, object converterParam = null)
        {
            if (converter == default)
            {
                if (typeof(TTargetProperty) == typeof(string) && mode == BindingMode.OneWay)
                {
                    _converter = new BaseStringValueConverter<TSourceProperty>();
                    _converterParam = converterParam;
                }
                else
                    throw new ArgumentException(Strings.RxDataBindings_noValueConverter);
            } 
            else 
                base.SetupConverter(mode, converter, converterParam);
        }

        protected override TTargetProperty ConvertToTargetProperty(TSourceProperty sourceProperty) 
            => (TTargetProperty)_converter.Convert(sourceProperty, typeof(TTargetProperty), _converterParam, CultureInfo.CurrentUICulture);

        protected override TSourceProperty ConvertToSourceProperty(TTargetProperty targetProperty) 
            => (TSourceProperty)_converter.ConvertBack(targetProperty, typeof(TTargetProperty), _converterParam, CultureInfo.CurrentUICulture);
    }

    public class RxBinding<TProperty> : RxBindingBase<TProperty, TProperty>
    {
        public RxBinding(ITargetProxy targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null) 
            : base(targetProxy, sourceProperty, mode, converter, converterParam) { }

        public RxBinding(ITargetProxy targetProxy, IPropertySetterProxy<TProperty> sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null) 
            : base(targetProxy, sourceProperty, mode, converter, converterParam) { }

        public RxBinding(IPropertySetterProxy<TProperty> targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null) 
            : base(targetProxy, sourceProperty, mode, converter, converterParam) { }

        protected override TProperty ConvertToSourceProperty(TProperty targetProperty) 
            => _converter != default ? (TProperty)_converter.Convert(targetProperty, typeof(TProperty), _converterParam, CultureInfo.CurrentUICulture) : targetProperty;

        protected override TProperty ConvertToTargetProperty(TProperty sourceProperty) 
            => _converter != default ? (TProperty)_converter.Convert(sourceProperty, typeof(TProperty), _converterParam, CultureInfo.CurrentUICulture) : sourceProperty;
    }
}
