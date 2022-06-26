using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public abstract class BaseUIViewVisibilityTargetProxy<TVisibility> : ValueAcceptor_iOSTargetProxy<UIView, TVisibility>
    {
        public BaseUIViewVisibilityTargetProxy(UIView target) : base(target) { }

        protected abstract bool IsHidden(TVisibility value);

        protected override void AcceptValue(TVisibility value) => Target.Hidden = IsHidden(value);
    }
}