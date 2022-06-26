using System;

namespace EvilGenius.RxDataBindings.Bindings
{
    public interface IFluentBindingDescription
    {
        IDisposable Apply();
    }
}
