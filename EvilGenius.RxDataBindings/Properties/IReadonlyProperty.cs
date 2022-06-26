using System;

namespace EvilGenius.RxDataBindings.Properties
{
    public interface IReadonlyProperty<out T> : IRxBaseProperty, IObservable<T>
    {
        T Value { get; }
    }
}
