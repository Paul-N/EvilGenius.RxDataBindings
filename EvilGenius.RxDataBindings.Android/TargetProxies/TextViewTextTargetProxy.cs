using Android.Text;
using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class TextViewTextTargetProxy : ValueAcceptorProviderAndroidTargetProxy<TextView, string>
    {
        private readonly bool _isEditTextBinding;

        public TextViewTextTargetProxy(TextView target) : base(target)
        {
            _isEditTextBinding = target is EditText;

            if (_isEditTextBinding)
                target.AfterTextChanged += OnAfterTextChanged;
        }

        private void OnAfterTextChanged(object sender, AfterTextChangedEventArgs e) => this.ProvideValue(Target?.Text);

        protected override void AcceptValue(string value)
        {
            if(Target != null)
                Target.SetText(value, TextView.BufferType.Normal);
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.AfterTextChanged -= OnAfterTextChanged;

            base.Dispose(disposing);
        }
    }
}