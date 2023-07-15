using EvilGenius.RxDataBindings.Proxies;
using System;
using System.Windows.Input;

namespace EvilGenius.RxDataBindings.Bindings;

public class CommandBinding : IDisposable
{
    private ICommand _command;
    private CommandTargetProxy _eventBindingProxy;
    private object _commandParamter;
    private bool _disposedValue;

    public CommandBinding(CommandTargetProxy eventBindingProxy, ICommand command, object commandParamter = null)
    {
        _eventBindingProxy = eventBindingProxy;
        _command = command;
        _command.CanExecuteChanged += OnCommandCanExecuteChanged;
        _eventBindingProxy.OnCommandFired += OnTargetEvent;
        _commandParamter = commandParamter;
    }

    private void OnCommandCanExecuteChanged(object sender, EventArgs e) 
        => _eventBindingProxy.CanExecuteChanged(_command.CanExecute(_commandParamter));

    private void OnTargetEvent(object sender, EventArgs e)
    {
        if (_command.CanExecute(_commandParamter))
            _command.Execute(_commandParamter);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _command.CanExecuteChanged -= OnCommandCanExecuteChanged;
            }

            _eventBindingProxy.OnCommandFired -= OnTargetEvent;
            _eventBindingProxy.Dispose();
            _disposedValue = true;
            _eventBindingProxy = null;
            _command = null;
            _commandParamter = null;
        }
    }

    ~CommandBinding() => Dispose(disposing: false);

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
