using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class ClickableTextViewGetterSetterTargetProxy : ValueAcceptorProviderTargetProxy<string>
    {
        private bool _isDisposed;
        private ClickableTextView _target;

        public ClickableTextViewGetterSetterTargetProxy(ClickableTextView target)
        {
            _target = target;
            _target.OnTextChanged += OnTextChanged;
        }

        protected override void AcceptValue(string value)
        {
            _target.Text = value;
        }

        private void OnTextChanged(object sender, ValueEventArgs<string> e) => ProvideValue(e.Value);

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_target != null)
                        _target.OnTextChanged -= OnTextChanged;
                }

                _target = null;
                _isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
