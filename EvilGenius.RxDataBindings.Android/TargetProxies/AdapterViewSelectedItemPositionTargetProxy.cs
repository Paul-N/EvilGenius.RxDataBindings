using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class AdapterViewSelectedItemPositionTargetProxy : ValueAcceptorProviderAndroidTargetProxy<AdapterView, int>
    {
        public AdapterViewSelectedItemPositionTargetProxy(AdapterView target) : base(target)
        {
            target.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) => this.ProvideValue(e.Position);

        protected override void AcceptValue(int value) => Target.SetSelection(value);

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.ItemSelected -= OnItemSelected;
            Target = null;
            base.Dispose(disposing);
        }
    }
}