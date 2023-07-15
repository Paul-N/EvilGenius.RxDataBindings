using System;

namespace EvilGenius.RxDataBindings.Proxies;

public abstract class CommandTargetProxy : IDisposable
{
    private bool _isDisposed;

    public event EventHandler OnCommandFired;

    public virtual void CanExecuteChanged(bool canExecute) { }

    public virtual void FireCommand() => OnCommandFired?.Invoke(this, EventArgs.Empty);

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing) { }
            _isDisposed = true;
        }
    }

    ~CommandTargetProxy() => Dispose(disposing: false);

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
