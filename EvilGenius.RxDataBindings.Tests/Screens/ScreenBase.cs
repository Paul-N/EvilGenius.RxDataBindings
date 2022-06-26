using System;

namespace EvilGenius.RxDataBindings.Tests.Screens
{
    internal class ScreenBase<TViewModel> : IDisposable where TViewModel : new()
    {
        private bool _isDisposed;

        public TViewModel ViewModel { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    ViewModel.DisposeIfDisposable();
                }

                ViewModel = default;
                _isDisposed = true;
            }
        }

        ~ScreenBase() => Dispose(disposing: false);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
