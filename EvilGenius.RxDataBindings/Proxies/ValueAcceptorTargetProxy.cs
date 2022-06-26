using System;

namespace EvilGenius.RxDataBindings.Proxies
{
    public abstract class ValueAcceptorTargetProxy<T> : ITargetProxy, IObserver<T>, IDisposable
    {
        protected abstract void AcceptValue(T value);

        #region IDisposable impl

        protected virtual void Dispose(bool disposing) { }

        ~ValueAcceptorTargetProxy() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IObserver<T>

        public void OnCompleted() => Dispose();

        public void OnError(Exception error) => throw error;

        public void OnNext(T value) => AcceptValue(value);

        #endregion
    }
}
