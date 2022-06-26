using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIViewHiddenTargetProxy : BaseUIViewVisibilityTargetProxy<bool>
    {
        public UIViewHiddenTargetProxy(UIView target) : base(target) { }

        protected override bool IsHidden(bool value) => value;
    }
}