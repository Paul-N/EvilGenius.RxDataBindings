using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIActivityIndicatorViewHiddenTargetProxy : ValueAcceptor_iOSTargetProxy<UIActivityIndicatorView, bool>
    {
        public UIActivityIndicatorViewHiddenTargetProxy(UIActivityIndicatorView target) : base(target) { }

        protected override void AcceptValue(bool value)
        {
            Target.Hidden = value;

            if (Target.Hidden)
                Target.StopAnimating();
            else
                Target.StartAnimating();
        }
    }
}