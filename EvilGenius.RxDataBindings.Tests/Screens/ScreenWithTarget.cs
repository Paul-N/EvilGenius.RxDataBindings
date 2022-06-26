using System;
using System.Reactive.Disposables;

namespace EvilGenius.RxDataBindings.Tests.Screens
{
    internal class ScreenWithTarget<TTarget, TViewModel> : ScreenBase<TViewModel> where TViewModel : new() where TTarget : new()
    {
        private bool _isDisposed;

        protected CompositeDisposable _disposableBag = new();
        
        public TTarget Target { get; private set; }

        public ScreenWithTarget()
        {
            Target = new TTarget();
            ViewModel = new TViewModel();
            SetBindings();
        }

        protected virtual void SetBindings() { }

        public void SetBindings(Action<TTarget, TViewModel, CompositeDisposable> bindingCreator) => bindingCreator(Target, ViewModel, _disposableBag);

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _disposableBag?.Dispose();
                }

                _disposableBag = null;
                Target = default;
                _isDisposed = true;
            }
        }
    }
}
