using Android.Views;
using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class TextViewFocusTargetProxy : ValueAcceptorProviderAndroidTargetProxy<EditText, string>
    {
        public TextViewFocusTargetProxy(EditText target) : base(target) => target.FocusChange += OnFocusChange;

        private void OnFocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (Target == null) return;

            if (!e.HasFocus)
                ProvideValue(Target.Text);
        }

        protected override void AcceptValue(string value) => Target.Text = value ?? string.Empty;

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.FocusChange -= OnFocusChange;

            base.Dispose(disposing);
        }
    }
}