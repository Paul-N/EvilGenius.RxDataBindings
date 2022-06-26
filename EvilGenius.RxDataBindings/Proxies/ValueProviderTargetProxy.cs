using System;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Proxies
{
    public class ValueProviderTargetProxy<T> : ITargetProxy, IObservable<T>, IDisposable
    {
        private IObserver<T> _valueObserver;

        protected void ProvideValue(T value) => _valueObserver?.OnNext(value);

        #region IDisposable impl

        private bool _isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _valueObserver?.DisposeIfDisposable();
                _valueObserver = null;
                _isDisposed = true;
            }
        }

        ~ValueProviderTargetProxy() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IObservable<T> impl

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _valueObserver.DisposeIfDisposable();
            _valueObserver = observer;

            return Disposable.Create(() =>
            {
                _valueObserver?.DisposeIfDisposable();
                _valueObserver = null;
            });
        }

        #endregion
    }
}
