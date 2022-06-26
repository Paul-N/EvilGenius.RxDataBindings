using System;

namespace EvilGenius.RxDataBindings.Proxies
{
    internal class PropertySetterProxy<T, TProperty> : IPropertySetterProxy<TProperty>, IDisposable
    {
        private bool _isDisposed;
        private T _object;
        private Action<T, object> _setter;

        public PropertySetterProxy(T object_, Action<T, object> setter)
        {
            if (object_ == null)
                throw new ArgumentNullException(nameof(object_));

            if (setter == null)
                throw new ArgumentNullException(nameof(setter));

            _object = object_;
            _setter = setter;
        }

        #region IObserver impl

        public void OnCompleted() => Dispose();

        public void OnError(Exception error) => throw error;

        public void OnNext(TProperty value) => _setter.Invoke(_object, value);

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _object = default;
                _setter = null;
                _isDisposed = true;
            }
        }

        ~PropertySetterProxy() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
