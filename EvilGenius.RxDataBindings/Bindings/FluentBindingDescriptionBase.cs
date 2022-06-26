using EvilGenius.Common.Logging;
using EvilGenius.RxDataBindings.Converters;
using EvilGenius.RxDataBindings.Properties;
using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using EvilGenius.RxDataBindings.Utils;
using System;
using System.Linq.Expressions;

namespace EvilGenius.RxDataBindings.Bindings
{
    public abstract class FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> : IFluentBindingDescription
    {
        protected TTarget _target;
        protected BindingMode _mode = BindingMode.Default;
        protected IValueConverter _converter;
        protected object _converterParameter;

        private ILogger _logger = new DebugLogger();

        internal OneOfSourceProperty _sourceProperty;

        internal OneOfTargetProxy _targetProxy;

        public FluentBindingDescriptionBase(TTarget target) => _target = target;

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> For(Func<TTarget, ValueAcceptorTargetProxy<TTargetProperty>> targetProxy)
        {
            _targetProxy = OneOfTargetProxy.FromValueAcceptorTargetProxy(targetProxy(_target));
            _target = default;
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> For(Func<TTarget, ValueProviderTargetProxy<TTargetProperty>> targetProxy)
        {
            _targetProxy = OneOfTargetProxy.FromValueProviderTargetProxy(targetProxy(_target));
            _target = default;
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> For(Func<TTarget, ValueAcceptorProviderTargetProxy<TTargetProperty>> targetProxy)
        {
            _targetProxy = OneOfTargetProxy.FromValueAcceptorProviderTargetProxy(targetProxy(_target));
            _target = default;
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> For(Expression<Func<TTarget, TTargetProperty>> targetPropSetter)
        {
            var targetProxy = targetPropSetter.ToPropertySetterProxy(_target) as PropertySetterProxy<TTarget, TTargetProperty>;
            _targetProxy = OneOfTargetProxy.FromPropertySetterSourceProxy(targetProxy);
            _target = default;
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> TwoWay() => Mode(BindingMode.TwoWay);

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> OneWay() => Mode(BindingMode.OneWay);

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> OneWayToSource() => Mode(BindingMode.OneWayToSource);

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> Mode(BindingMode mode)
        {
            _mode = mode;
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> To<TProperty>(IReadonlyProperty<TProperty> readonlyProperty)
        {
            _sourceProperty = OneOfSourceProperty.FromReadonlyProperty(readonlyProperty);
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> To<TProperty>(IProperty<TProperty> property)
        {
            _sourceProperty = OneOfSourceProperty.FromProperty(property);
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> To<TSource, TProperty>(
            (TSource viewModel, Expression<Func<TSource, TProperty>> sourcePropSetter) sourcePropertyAndSetter)
        {
            var sourceProxy = sourcePropertyAndSetter.sourcePropSetter.ToPropertySetterProxy(sourcePropertyAndSetter.viewModel) as PropertySetterProxy<TSource, TProperty>;
            _sourceProperty = OneOfSourceProperty.FromPropertySetterSourceProxy(sourceProxy);
            return this;
        }

        public FluentBindingDescriptionBase<TTarget, TSourceProperty, TTargetProperty> WithConversion(IValueConverter converter, object converterParameter = null)
        {
            _converter = converter;
            _converterParameter = converterParameter;
            return this;
        }

        public abstract IDisposable Apply();

        protected virtual void Clean()
        {
            _target = default;
            _converter = default;
            _converterParameter = default;

            _sourceProperty?.Dispose();
            _sourceProperty = null;

            _targetProxy?.Dispose();
            _targetProxy = null;
    }

        protected void FixBindingModeIfNeeded(BindingMode modeToSet)
        {
            if (_mode != modeToSet && _mode != BindingMode.Default)
            {
                _logger?.Log(LogLevel.Info, LibTag.Tag, string.Format(Strings.RxDataBindings_type_of_binding_expectedX_butY_template, _mode, modeToSet));
                _mode = modeToSet;
            }
        }
    }
}
