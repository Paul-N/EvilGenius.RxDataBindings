using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class ClickableTextViewCommandProxy : CommandTargetProxy
    {
        private bool _isDisposed;
        private ClickableTextView _target;

        public ClickableTextViewCommandProxy(ClickableTextView target)
        {
            _target = target;
            _target.OnClicked += OnClicked;
        }

        public override void CanExecuteChanged(bool canExecute) => _target.IsEnabled = canExecute;

        private void OnClicked(object sender, ValueEventArgs<(int, int)> e) => FireCommand();

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_target != null)
                        _target.OnClicked -= OnClicked;
                }

                _target = null;
                _isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
