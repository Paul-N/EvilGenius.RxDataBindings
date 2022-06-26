using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UILabelTextTargetProxy : ValueAcceptor_iOSTargetProxy<UILabel, string>
    {
        public UILabelTextTargetProxy(UILabel target) : base(target) { }

        protected override void AcceptValue(string value) => Target.Text = value;
    }
}