using EvilGenius.RxDataBindings.Properties;
using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using OneOf;
using System;

namespace EvilGenius.RxDataBindings.Bindings;

internal class OneOfSourceProperty : IOneOf
{
    private IPropertySetterProxy _value0;
    private IRxBaseProperty _value1;
    private IRxBaseProperty _value2;


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
                _ => throw new InvalidOperationException()
            };
        }
    }

    #endregion

    protected OneOfSourceProperty(IPropertySetterProxy propertySetterProxy)
    {
        this._value0 = propertySetterProxy;
        _index = 0;
    }

    protected OneOfSourceProperty(IRxBaseProperty property, int index)
    {
        switch (index)
        {
            case 1:
                _value1 = property;
                _index = 1;
                break;
            case 2:
                _value2 = property;
                _index = 2;
                break;
            default:
                throw new InvalidOperationException(Strings.RxDataBindings_tryingSetUnknownProp);
        }
        _index = index;
    }

    public static OneOfSourceProperty FromPropertySetterSourceProxy<TSource, TProperty>(PropertySetterProxy<TSource, TProperty> propertySetterProxy) 
        => new OneOfSourceProperty(propertySetterProxy);

    public static OneOfSourceProperty FromReadonlyProperty<TProperty>(IReadonlyProperty<TProperty> roProperty) => new OneOfSourceProperty(roProperty, 1);

    public static OneOfSourceProperty FromProperty<TProperty>(IProperty<TProperty> property) => new OneOfSourceProperty(property, 2);

    public bool IsPropertySetterSourceProxy => _index == 0 && CheckIsNotDisposed();

    public bool IsReadonlyProperty => _index == 1 && CheckIsNotDisposed();

    public bool IsProperty => _index == 2 && CheckIsNotDisposed();

    public IPropertySetterProxy<TProperty> AsPropertySetterSourceProxy<TProperty>() =>
        _index == 0 && CheckIsNotDisposed() ?
            _value0 as IPropertySetterProxy<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(IPropertySetterProxy)));

    public IReadonlyProperty<TProperty> AsReadonlyProperty<TProperty>() =>
        _index == 1 && CheckIsNotDisposed() ?
            _value1 as IReadonlyProperty<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(IReadonlyProperty<TProperty>)));

    public IProperty<TProperty> AsProperty<TProperty>() =>
        _index == 2 && CheckIsNotDisposed() ?
            _value2 as IProperty<TProperty> :
            throw new InvalidOperationException(StringsExtensions.ValueIsNot(nameof(IProperty<TProperty>)));

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
            _isDisposed = true;
        }
    }

    ~OneOfSourceProperty() => Dispose(disposing: false);

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
