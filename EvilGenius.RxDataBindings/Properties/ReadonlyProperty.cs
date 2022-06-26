using System;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Properties
{
    public class ReadonlyProperty<T> : IReadonlyProperty<T>
    {
        private List<IObserver<T>> _observers = new List<IObserver<T>>();

        internal T _value;

        public T Value => _value;

        public ReadonlyProperty(ref IPropertySetter<T> setter)
        {
            var setterToReturn = new PropertySetter(this);
            setter = setterToReturn;
        }

        public ReadonlyProperty(ref IPropertySetter<T> setter, T initValue) : this(ref setter) 
            => SetValueSilently(initValue);


        #region IObservable<T> impl

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            observer.OnNext(_value);
            return Disposable.Create(() => _observers?.Remove(observer));
        }

        #endregion

        protected void NotifyObservers()
        {
            if (_observers != null)
                foreach (var observer in _observers)
                    observer.OnNext(Value);
        }

        private void SetValue(T value, bool isSilently = false)
        {
            _value = value;
            if (!isSilently)
                NotifyObservers();
        }

        private void SetValueSilently(T value) => SetValue(value, isSilently: true);

        private class PropertySetter : IPropertySetter<T>
        {
            private readonly WeakReference<ReadonlyProperty<T>> _property;


            public PropertySetter(ReadonlyProperty<T> rxRoProperty) => _property = new WeakReference<ReadonlyProperty<T>>(rxRoProperty);

            public void Raise()
            {
                ReadonlyProperty<T> property = null;
                if (_property?.TryGetTarget(out property) == true)
                    property.NotifyObservers();
            }

            public void SetValue(T value, bool isSilently = false) 
            {
                ReadonlyProperty<T> property = null;
                if (_property?.TryGetTarget(out property) == true)
                    property.SetValue(value, isSilently: isSilently);
            }

            public void SetValueSilently(T value) => SetValue(value, isSilently: true);
        }
    }
}
