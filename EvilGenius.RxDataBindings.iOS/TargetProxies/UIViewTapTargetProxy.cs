using System;
using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using EvilGenius.RxDataBindings.iOS.Views;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIViewTapTargetProxy : Command_iOSTargetProxy<UIView>
    {
        private TapGestureRecognizerBehaviour _behaviour;

        public UIViewTapTargetProxy(UIView target, uint numberOfTapsRequired = 1, uint numberOfTouchesRequired = 1, bool cancelsTouchesInView = true) 
            : base(target)
        {
            _behaviour = new TapGestureRecognizerBehaviour(target, numberOfTapsRequired, numberOfTouchesRequired, cancelsTouchesInView);
            _behaviour.OnGesture += HandleGesture;
        }

        private void HandleGesture(object sender, EventArgs ea) => FireCommand();

        protected override void Dispose(bool disposing)
        {
            if (_behaviour != null)
            {
                _behaviour.OnGesture -= HandleGesture;
                _behaviour.Dispose();
                _behaviour = null;
            }

            base.Dispose(disposing);
        }
    }
}