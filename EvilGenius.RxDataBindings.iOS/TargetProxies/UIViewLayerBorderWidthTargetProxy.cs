using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIViewLayerBorderWidthTargetProxy : ValueAcceptor_iOSTargetProxy<UIView, float>
    {
        public UIViewLayerBorderWidthTargetProxy(UIView target) : base(target) { }

        protected override void AcceptValue(float value)
        {
            if (Target?.Layer == null) return;

            Target.Layer.BorderWidth = value;
        }
    }
}