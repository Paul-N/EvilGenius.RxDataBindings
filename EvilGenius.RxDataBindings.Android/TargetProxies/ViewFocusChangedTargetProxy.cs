using Android.Views;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewFocusChangedTargetProxy : CommandAndroidTargetProxy<View>
    {
        private View Target;

        public ViewFocusChangedTargetProxy(View target) : base(target) => Target.FocusChange += OnViewFocusChange;

        private void OnViewFocusChange(object sender, View.FocusChangeEventArgs e) => FireCommand();

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.FocusChange -= OnViewFocusChange;
            
            base.Dispose(disposing);
        }
    }
}