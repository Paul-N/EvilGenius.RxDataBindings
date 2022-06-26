using System;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Properties
{
    public class Property<T> : IProperty<T>
    {
        private List<IObserver<T>> _observers = new List<IObserver<T>>();

        internal T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotifyObservers();
            }
        }

        public Property(ref IPropertyRaiser raiser)
        {
            raiser = new PropertyRaiser(this);
        }

        public Property(ref IPropertyRaiser raiser, T initValue) : this(ref raiser)
            => Value = initValue;

        public Property() { }

        public Property(T initValue) : this()
            => Value = initValue;

        #region IObservable<T> impl

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            observer.OnNext(_value);
            return Disposable.Create(() => _observers?.Remove(observer));
        }

        #endregion

        #region IObserver<T> impl

        public void OnCompleted() { }

        public void OnError(Exception error) => throw error;

        public void OnNext(T value)
        {
            Value = value;
        }

        #endregion

        protected void NotifyObservers()
        {
            if (_observers != null)
                foreach (var observer in _observers)
                    observer.OnNext(Value);
        }

        private class PropertyRaiser : IPropertyRaiser
        {
            private readonly WeakReference<Property<T>> _property;
            
            public PropertyRaiser(Property<T> property) => _property = new WeakReference<Property<T>>(property);

            public void Raise()
            {
                Property<T> property = null;
                if (_property?.TryGetTarget(out property) == true)
                    property.NotifyObservers();
            }
        }
    }
}
