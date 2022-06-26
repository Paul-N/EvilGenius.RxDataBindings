using Android.Text;
using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using Java.Lang;
using OneOf;

#nullable enable

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class TextViewTextFormattedTargetProxy : ValueAcceptorProviderAndroidTargetProxy<TextView?, OneOf<ICharSequence?, ISpanned>>
    {
        private readonly bool _isEditTextBinding;

        public TextViewTextFormattedTargetProxy(TextView target) : base(target)
        {
            _isEditTextBinding = target is EditText;

            if (_isEditTextBinding)
                target.AfterTextChanged += OnAfterTextChanged;
        }

        private void OnAfterTextChanged(object sender, AfterTextChangedEventArgs e) 
            => this.ProvideValue(OneOf<ICharSequence?, ISpanned>.FromT0(Target?.TextFormatted));

        protected override void AcceptValue(OneOf<ICharSequence?, ISpanned> value)
        {
            if (Target != null)
                Target.TextFormatted = value.AsT1;
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.AfterTextChanged -= OnAfterTextChanged;

            base.Dispose(disposing);
        }
    }
}

#nullable disable