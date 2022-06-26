using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIViewVisibleTargetProxy : BaseUIViewVisibilityTargetProxy<bool>
    {
        public UIViewVisibleTargetProxy(UIView target) : base(target) { }

        protected override bool IsHidden(bool value) => !value;
    }
}