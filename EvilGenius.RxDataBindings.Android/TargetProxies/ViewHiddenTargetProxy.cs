using Android.Views;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewHiddenTargetProxy : ViewVisibilityBaseTargetProxy<bool>
    {
        public ViewHiddenTargetProxy(View target) : base(target) { }

        protected override ViewStates GetViewState(bool value) => value ? ViewStates.Gone : ViewStates.Visible;
    }
}