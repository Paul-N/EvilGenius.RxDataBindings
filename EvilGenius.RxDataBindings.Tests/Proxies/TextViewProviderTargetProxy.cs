using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class TextViewProviderTargetProxy : ValueProviderTargetProxy<string>
    {
        private TextView _textView;

        public TextViewProviderTargetProxy(TextView textView)
        {
            _textView = textView;
            _textView.OnTextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, ValueEventArgs<string> e) => ProvideValue(e.Value);

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
