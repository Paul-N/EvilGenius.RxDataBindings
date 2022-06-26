using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIButtonTitleTargetProxy : ValueAcceptor_iOSTargetProxy<UIButton, string>
    {
        private readonly UIControlState _state;

        public UIButtonTitleTargetProxy(UIButton target, UIControlState state = UIControlState.Normal) : base(target) => _state = state;

        protected override void AcceptValue(string value)
        {
            Target.SetTitle(value, _state);
        }
    }
}