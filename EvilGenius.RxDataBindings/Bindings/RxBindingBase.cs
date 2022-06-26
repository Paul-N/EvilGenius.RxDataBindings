using EvilGenius.RxDataBindings.Converters;
using EvilGenius.RxDataBindings.Properties;
using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using System;
using System.Globalization;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Bindings
{
    public abstract class RxBindingBase<TSourceProperty, TTargetProperty> : IDisposable
    {
        private bool _isDisposed;
        private int? _hashOfLastValue;
        private IDisposable _sourcePropertySubscription;
        private IDisposable _targetPropertySubscription;
        private IObserver<TSourceProperty> _sourcePropertyObserver;
        private IObserver<TTargetProperty> _targetPropertyObserver;
        protected IValueConverter _converter;
        protected object _converterParam;
        private IDisposable _targetDisposable;

        public RxBindingBase(ITargetProxy targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
        {
            SetupConverter(mode, converter, converterParam);

            switch (mode)
            {
                case BindingMode.Default:
                    throw new ArgumentException(string.Format(Strings.RxDataBindings_binding_mode_is_default_template, nameof(BindingMode), BindingMode.Default));
                case BindingMode.TwoWay:
                    _sourcePropertyObserver = (sourceProperty as IObserver<TSourceProperty>);
                    _targetPropertySubscription = (targetProxy as IObservable<TTargetProperty>).Subscribe(OnTargetPropertyEmitted);
                    _targetPropertyObserver = (targetProxy as IObserver<TTargetProperty>);
                    _sourcePropertySubscription = (sourceProperty as IObservable<TSourceProperty>).Subscribe(OnSourcePropertyEmitted);
                    break;
                case BindingMode.OneWay:
                    _targetPropertyObserver = (targetProxy as IObserver<TTargetProperty>);
                    _sourcePropertySubscription = (sourceProperty as IObservable<TSourceProperty>).Subscribe(OnSourcePropertyEmitted);
                    break;
                case BindingMode.OneWayToSource:
                    _sourcePropertyObserver = (sourceProperty as IObserver<TSourceProperty>);
                    _targetPropertySubscription = (targetProxy as IObservable<TTargetProperty>).Subscribe(OnTargetPropertyEmitted);
                    break;
                case BindingMode.FireCommand:
                    throw new ArgumentException(string.Format(Strings.RxDataBindings_misuse_of_firecommand_mode_template, BindingMode.FireCommand, nameof(CommandBinding)));
                default:
                    throw new ArgumentException($"{Strings.RxDataBindings_unknown} {nameof(BindingMode)}");
            }

            _targetDisposable = Disposable.Create(() => targetProxy?.DisposeIfDisposable());
        }

        public RxBindingBase(ITargetProxy targetProxy, IPropertySetterProxy<TSourceProperty> sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
        {
            SetupConverter(mode, converter, converterParam);

            if (mode != BindingMode.OneWayToSource)
                throw new ArgumentException(StringsExtensions.SrcPropertySupportOnly(BindingMode.OneWayToSource));

            _sourcePropertyObserver = (sourceProperty as IObserver<TSourceProperty>);
            _targetPropertySubscription = (targetProxy as IObservable<TTargetProperty>).Subscribe(OnTargetPropertyEmitted);

            _targetDisposable = Disposable.Create(() => targetProxy?.DisposeIfDisposable());
        }

        public RxBindingBase(IPropertySetterProxy<TTargetProperty> targetProxy, IRxBaseProperty sourceProperty, BindingMode mode, IValueConverter converter, object converterParam = null)
        {
            SetupConverter(mode, converter, converterParam);

            if (mode != BindingMode.OneWay)
                throw new ArgumentException(StringsExtensions.SrcPropertySupportOnly(BindingMode.OneWay));

            _targetPropertyObserver = (targetProxy as IObserver<TTargetProperty>);
            _sourcePropertySubscription = (sourceProperty as IObservable<TSourceProperty>).Subscribe(OnSourcePropertyEmitted);

            _targetDisposable = Disposable.Create(() => targetProxy?.DisposeIfDisposable());
        }

        protected virtual void SetupConverter(BindingMode mode, IValueConverter converter, object converterParam = null)
        {
            _converter = converter;
            _converterParam = converterParam;
        }

        protected void OnSourcePropertyEmitted(TSourceProperty sourceProperty)
        {
            var hashOfCurrentValue = sourceProperty?.GetHashCode();
            
            if (_hashOfLastValue == hashOfCurrentValue)
                return; //Prevent loop => StackOverflowException
            else
                _hashOfLastValue = sourceProperty?.GetHashCode();

            var converted = ConvertToTargetProperty(sourceProperty);
            _targetPropertyObserver?.OnNext(converted);
        }

        private void OnTargetPropertyEmitted(TTargetProperty targetProperty)
        {
            var converted = ConvertToSourceProperty(targetProperty);
            _sourcePropertyObserver?.OnNext(converted);
        }

        protected virtual TTargetProperty ConvertToTargetProperty(TSourceProperty sourceProperty)
            => (TTargetProperty)_converter.Convert(sourceProperty, typeof(TTargetProperty), _converterParam, CultureInfo.CurrentUICulture);

        protected virtual TSourceProperty ConvertToSourceProperty(TTargetProperty targetProperty)
            => (TSourceProperty)_converter.ConvertBack(targetProperty, typeof(TTargetProperty), _converterParam, CultureInfo.CurrentUICulture);

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _sourcePropertySubscription?.Dispose();
                    _targetPropertySubscription?.Dispose();
                }
                _targetDisposable?.Dispose();
                _targetDisposable = null;

                _sourcePropertySubscription = null;
                _targetPropertySubscription = null;
                _sourcePropertyObserver = null;
                _targetPropertyObserver = null;
                _converter = default;
                _converterParam = null;

        _isDisposed = true;
            }
        }

        ~RxBindingBase() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
