using Android.Views;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public abstract class ViewVisibilityBaseTargetProxy<TVisibility> : ValueAcceptorAndroidTargetProxy<View, TVisibility>
    {
        public ViewVisibilityBaseTargetProxy(View target) : base(target) { }

        protected abstract ViewStates GetViewState(TVisibility value);
        
        protected override void AcceptValue(TVisibility value)
        {
            if (Target != null)
                Target.Visibility = GetViewState(value);
        }
    }
}