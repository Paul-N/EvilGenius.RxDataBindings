using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using System;
using System.Windows.Input;

namespace EvilGenius.RxDataBindings.Bindings;

public class FluentBindingDescription<TTarget> : IFluentBindingDescription
{
    private TTarget _target;
    private object _commandParameter;

    private ICommand _sourceProperty;

    private CommandTargetProxy _targetProperty;

    public FluentBindingDescription(TTarget target) => _target = target;

    public FluentBindingDescription<TTarget> For(Func<TTarget, CommandTargetProxy> targetProxy)
    {
        _targetProperty = targetProxy(_target);
        _target = default;
        return this;
    }

    public FluentBindingDescription<TTarget> To(ICommand command)
    {
        _sourceProperty = command;
        return this;
    }

    public FluentBindingDescription<TTarget> CommandParameter(object parameter)
    {
        _commandParameter = parameter;
        return this;
    }

    public IDisposable Apply()
    {
        if (_targetProperty == null)
            throw new NullReferenceException(Strings.RxDataBindings_noTargetProxy);

        if (_sourceProperty == null)
            throw new NullReferenceException(Strings.RxDataBindings_noSourceProperty);

        var bindingToReturn = new CommandBinding(_targetProperty, _sourceProperty, _commandParameter);
        Clean();
        return bindingToReturn;

    }

    protected virtual void Clean()
    {
        _target = default;
        _commandParameter = null;
        _sourceProperty = null;
        _targetProperty = null;
    }
}
