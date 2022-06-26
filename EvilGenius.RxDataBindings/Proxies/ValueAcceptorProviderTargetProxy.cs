using System;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Proxies
{
    public abstract class ValueAcceptorProviderTargetProxy<T> : ITargetProxy, IObservable<T>, IObserver<T>, IDisposable
    {

        private IObserver<T> _valueObserver;

        protected abstract void AcceptValue(T value);

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

        ~ValueAcceptorProviderTargetProxy() => Dispose(disposing: false);

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

        #region IObserver<T>

        public void OnCompleted() => Dispose(disposing: true);

        public void OnError(Exception error) => throw error;

        public void OnNext(T value) => AcceptValue(value);

        #endregion
    }
}
