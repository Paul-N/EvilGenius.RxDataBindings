using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class TextViewTargetProxy : ValueAcceptorProviderTargetProxy<string>
    {
        private TextView _textView;

        public TextViewTargetProxy(TextView textView)
        {
            _textView = textView;
            _textView.OnTextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, ValueEventArgs<string> e) => ProvideValue(e.Value);

        protected override void AcceptValue(string value) => _textView.Text = value;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_textView != null)
                {
                    _textView.OnTextChanged -= OnTextChanged;
                }
            }
            _textView = null;
            base.Dispose(disposing);
        }
    }
}
