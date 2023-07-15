using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using OneOf;
using System;

namespace EvilGenius.RxDataBindings.Bindings;

internal sealed class OneOfTargetProxy : IOneOf, IDisposable
{
    private IPropertySetterProxy _value0;
    private ITargetProxy _value1;
    private ITargetProxy _value2;
    private ITargetProxy _value3;


    #region IOneOf impl

    readonly int _index;

    public int Index => _index;

    public object Value
    {
        get
        {
            CheckIsNotDisposed();

            return _index switch
            {
                0 => _value0,
                1 => _value1,
                2 => _value2,
                3 => _value3,
                _ => throw new InvalidOperationException()
            };
        }
    }

    #endregion

    private OneOfTargetProxy(IPropertySetterProxy propertySetterProxy)
    {
        this._value0 = propertySetterProxy;
        _index = 0;
    }

    private OneOfTargetProxy(ITargetProxy targetProxy, int index)
    {
        switch (index)
        {
            case 1:
                _value1 = targetProxy;
                _index = 1;
                break;
            case 2:
                _value2 = targetProxy;
                _index = 2;
                break;
            case 3:
                _value3 = targetProxy;
                _index = 3;
                break;
            default:
                throw new InvalidOperationException(Strings.RxDataBindings_tryingSetUnknownProp);
        }
        _index = index;
    }

    public static OneOfTargetProxy FromPropertySetterSourceProxy<TTarget, TProperty>(PropertySetterProxy<TTarget, TProperty> propertySetterProxy) 
        => new OneOfTargetProxy(propertySetterProxy);

    public static OneOfTargetProxy FromValueAcceptorTargetProxy<TProperty>(ValueAcceptorTargetProxy<TProperty> targetProxy) => new OneOfTargetProxy(targetProxy, 1);

    public static OneOfTargetProxy FromValueProviderTargetProxy<TProperty>(ValueProviderTargetProxy<TProperty> targetProxy) => new OneOfTargetProxy(targetProxy, 2);

    public static OneOfTargetProxy FromValueAcceptorProviderTargetProxy<TProperty>(ValueAcceptorProviderTargetProxy<TProperty> targetProxy) 
        => new OneOfTargetProxy(targetProxy, 3);

    public bool IsPropertySetterTargetProxy => _index == 0 && CheckIsNotDisposed();

    public bool IsValueAcceptorTargetProxy => _index == 1 && CheckIsNotDisposed();

    public bool IsValueProviderTargetProxy => _index == 2 && CheckIsNotDisposed();

    public bool IsValueAcceptorProviderTargetProxy => _index == 3 && CheckIsNotDisposed();

    public IPropertySetterProxy<TProperty> AsPropertySetterTargetProxy<TProperty>() =>
        _index == 0 && CheckIsNotDisposed() ?
            _value0 as IPropertySetterProxy<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(IPropertySetterProxy)));

    public ValueAcceptorTargetProxy<TProperty> AsValueAcceptorTargetProxy<TProperty>() =>
        _index == 1 && CheckIsNotDisposed() ?
            _value1 as ValueAcceptorTargetProxy<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(ValueAcceptorTargetProxy<TProperty>)));

    public ValueProviderTargetProxy<TProperty> AsValueProviderTargetProxy<TProperty>() =>
        _index == 2 && CheckIsNotDisposed() ?
            _value2 as ValueProviderTargetProxy<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(ValueProviderTargetProxy<TProperty>)));

    public ValueAcceptorProviderTargetProxy<TProperty> AsValueAcceptorProviderTargetProxy<TProperty>() =>
        _index == 3 && CheckIsNotDisposed() ?
            _value3 as ValueAcceptorProviderTargetProxy<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(ValueAcceptorProviderTargetProxy<TProperty>)));


    private bool CheckIsNotDisposed() => _isDisposed ? throw new InvalidOperationException(Strings.RxDataBindings_objIsDisposed) : true;
    
    #region IDsiposable impl
    
    private bool _isDisposed;

    private void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            _value0 = default;
            _value1 = default;
            _value2 = default;
            _value3 = default;
            _isDisposed = true;
        }
    }

    ~OneOfTargetProxy() => Dispose(disposing: false);

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
