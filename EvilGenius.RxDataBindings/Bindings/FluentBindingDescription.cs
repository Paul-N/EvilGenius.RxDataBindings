using EvilGenius.RxDataBindings.Converters;
using EvilGenius.RxDataBindings.Properties;
using EvilGenius.RxDataBindings.Resources;
using System;
using System.Linq;

namespace EvilGenius.RxDataBindings.Bindings
{

    public class FluentBindingDescription<TTarget, TSourceProperty, TTargetProperty> : FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty>
    {
        public FluentBindingDescription(TTarget target) : base(target) { }

        public override IDisposable Apply()
        {
            if (_targetProxy.IsValueAcceptorTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsValueAcceptorTargetProxy<TTargetProperty>();

                IRxBaseProperty sourceProperty = null;

                if (_sourceProperty.IsReadonlyProperty)
                    sourceProperty = _sourceProperty.AsReadonlyProperty<TSourceProperty>();
                else if (_sourceProperty.IsProperty)
                    sourceProperty = _sourceProperty.AsProperty<TSourceProperty>();
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);

                _converter = CheckAndSetConverter(_mode, _converter);

                var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                Clean();
                return binding;
            }
            else if (_targetProxy.IsValueProviderTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsValueProviderTargetProxy<TTargetProperty>();

                _converter = CheckAndSetConverter(_mode, _converter);

                if (_sourceProperty.IsProperty)
                {
                    var sourceProperty = _sourceProperty.AsProperty<TSourceProperty>();


                    var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsPropertySetterSourceProxy)
                {
                    var sourceProperty = _sourceProperty.AsPropertySetterSourceProxy<TSourceProperty>();


                    var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);


            }
            else if (_targetProxy.IsValueAcceptorProviderTargetProxy)
            {
                var targetProxy = _targetProxy.AsValueAcceptorProviderTargetProxy<TTargetProperty>();

                _converter = CheckAndSetConverter(_mode, _converter);

                if (_sourceProperty.IsReadonlyProperty)
                {
                    FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                    _converter = CheckAndSetConverter(_mode, _converter);

                    var sourceProperty = _sourceProperty.AsReadonlyProperty<TSourceProperty>();


                    var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsProperty)
                {
                    if (!_mode.IsRxBindingMode())
                    {
                        var rxBindingModesStr = string.Join(',', BindingModeExtensions.RxBindingModes.Select(m => m.ToString()));
                        throw new InvalidOperationException(string.Format(Strings.RxDataBindings_allowed_types_binding_are_template, rxBindingModesStr));
                    }

                    _converter = CheckAndSetConverter(_mode, _converter);
                    var sourceProperty = _sourceProperty.AsProperty<TSourceProperty>();


                    var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsPropertySetterSourceProxy)
                {
                    FixBindingModeIfNeeded(modeToSet: BindingMode.OneWayToSource);
                    _converter = CheckAndSetConverter(_mode, _converter);

                    var sourceProperty = _sourceProperty.AsPropertySetterSourceProxy<TSourceProperty>();


                    var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);
            }
            else if (_targetProxy.IsPropertySetterTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsPropertySetterTargetProxy<TTargetProperty>();

                IRxBaseProperty sourceProperty = null;

                if (_sourceProperty.IsReadonlyProperty)
                    sourceProperty = _sourceProperty.AsReadonlyProperty<TSourceProperty>();
                else if (_sourceProperty.IsProperty)
                    sourceProperty = _sourceProperty.AsProperty<TSourceProperty>();
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);


                _converter = CheckAndSetConverter(_mode, _converter);

                var binding = new RxBinding<TTargetProperty, TSourceProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                Clean();
                return binding;

            }
            else
                throw new InvalidOperationException(Strings.RxDataBindings_targetProxyNotSupported);
        }

        private IValueConverter CheckAndSetConverter(BindingMode mode, IValueConverter converter)
        {
            if (converter != default)
                return converter;
            else if (typeof(TTargetProperty) == typeof(string) && mode == BindingMode.OneWay)
                return new BaseStringValueConverter<TSourceProperty>();
            else
                throw new InvalidOperationException(Strings.RxDataBindings_noValueConverter);
        }
    }

    public class FluentBindingDescription<TTarget, TProperty> : FluentBindingDescriptionBase<TTarget, TProperty, TProperty>
    {
        public FluentBindingDescription(TTarget target) : base(target) { }

        public override IDisposable Apply()
        {
            if (_targetProxy.IsValueAcceptorTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsValueAcceptorTargetProxy<TProperty>();

                IRxBaseProperty sourceProperty = null;

                if (_sourceProperty.IsReadonlyProperty)
                    sourceProperty = _sourceProperty.AsReadonlyProperty<TProperty>();
                else if (_sourceProperty.IsProperty)
                    sourceProperty = _sourceProperty.AsProperty<TProperty>();
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);


                var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                Clean();
                return binding;
            }
            else if (_targetProxy.IsValueProviderTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsValueProviderTargetProxy<TProperty>();

                if (_sourceProperty.IsProperty)
                {
                    var sourceProperty = _sourceProperty.AsProperty<TProperty>();

                    var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsPropertySetterSourceProxy)
                {
                    var sourceProperty = _sourceProperty.AsPropertySetterSourceProxy<TProperty>();

                    var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);


            }
            else if (_targetProxy.IsValueAcceptorProviderTargetProxy)
            {
                var targetProxy = _targetProxy.AsValueAcceptorProviderTargetProxy<TProperty>();

                if (_sourceProperty.IsReadonlyProperty)
                {
                    FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);

                    var sourceProperty = _sourceProperty.AsReadonlyProperty<TProperty>();


                    var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsProperty)
                {
                    if (!_mode.IsRxBindingMode())
                    {
                        var rxBindingModesStr = string.Join(',', BindingModeExtensions.RxBindingModes.Select(m => m.ToString()));
                        throw new InvalidOperationException(string.Format(Strings.RxDataBindings_allowed_types_binding_are_template, rxBindingModesStr));
                    }
                    var sourceProperty = _sourceProperty.AsProperty<TProperty>();


                    var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else if (_sourceProperty.IsPropertySetterSourceProxy)
                {
                    FixBindingModeIfNeeded(modeToSet: BindingMode.OneWayToSource);

                    var sourceProperty = _sourceProperty.AsPropertySetterSourceProxy<TProperty>();


                    var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                    Clean();
                    return binding;
                }
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);
            }
            else if (_targetProxy.IsPropertySetterTargetProxy)
            {
                FixBindingModeIfNeeded(modeToSet: BindingMode.OneWay);
                var targetProxy = _targetProxy.AsPropertySetterTargetProxy<TProperty>();

                IRxBaseProperty sourceProperty = null;

                if (_sourceProperty.IsReadonlyProperty)
                    sourceProperty = _sourceProperty.AsReadonlyProperty<TProperty>();
                else if (_sourceProperty.IsProperty)
                    sourceProperty = _sourceProperty.AsProperty<TProperty>();
                else throw new InvalidOperationException(Strings.RxDataBindings_WrongSourcePropertyType);

                var binding = new RxBinding<TProperty>(targetProxy, sourceProperty, _mode, _converter, _converterParameter);
                Clean();
                return binding;
            }
            else
            {
                Clean();
                throw new InvalidOperationException(Strings.RxDataBindings_targetProxyNotSupported);
            }
        }
    }
}
