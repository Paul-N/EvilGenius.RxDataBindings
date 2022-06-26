using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class CompoundButtonCheckedTargetProxy : ValueAcceptorProviderAndroidTargetProxy<CompoundButton, bool>
    {
        public CompoundButtonCheckedTargetProxy(CompoundButton target) : base(target)
        {
            target.CheckedChange += OnButtonCheckedChange;
        }

        private void OnButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) => this.ProvideValue(e.IsChecked);

        protected override void AcceptValue(bool value)
        {
            if (Target != null)
                Target.Checked = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.CheckedChange -= OnButtonCheckedChange;

            base.Dispose(disposing);
        }
    }
}