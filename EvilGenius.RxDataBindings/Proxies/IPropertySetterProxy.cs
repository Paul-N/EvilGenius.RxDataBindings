using System;

namespace EvilGenius.RxDataBindings.Proxies
{
    public interface IPropertySetterProxy { }

    public interface IPropertySetterProxy<TProperty> : IPropertySetterProxy, IObserver<TProperty>{ }
}
