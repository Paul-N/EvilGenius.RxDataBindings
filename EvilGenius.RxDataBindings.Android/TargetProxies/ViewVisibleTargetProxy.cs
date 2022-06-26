using Android.Views;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewVisibleTargetProxy : ViewVisibilityBaseTargetProxy<bool>
    {
        public ViewVisibleTargetProxy(View target) : base(target) { }

        protected override ViewStates GetViewState(bool value) => value ? ViewStates.Visible : ViewStates.Gone;
    }
}