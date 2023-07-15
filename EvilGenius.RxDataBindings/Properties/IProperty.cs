using System;

namespace EvilGenius.RxDataBindings.Properties;

public interface IProperty<T> : IRxBaseProperty, IObservable<T>, IObserver<T>
{
    T Value { get; set; }
}