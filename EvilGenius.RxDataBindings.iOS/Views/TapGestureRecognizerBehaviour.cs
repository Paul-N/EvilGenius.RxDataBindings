using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.Views
{
    public class TapGestureRecognizerBehaviour
        : GestureRecognizerBehavior<UITapGestureRecognizer>
    {
        public event EventHandler OnGesture;

        protected override void HandleGesture(UITapGestureRecognizer gesture)
            => OnGesture?.Invoke(this, EventArgs.Empty);

        public TapGestureRecognizerBehaviour(UIView target, uint numberOfTapsRequired = 1,
                                                uint numberOfTouchesRequired = 1,
                                                bool cancelsTouchesInView = true)
        {
            var tap = new UITapGestureRecognizer(HandleGesture)
            {
                NumberOfTapsRequired = numberOfTapsRequired,
                NumberOfTouchesRequired = numberOfTouchesRequired,
                CancelsTouchesInView = cancelsTouchesInView
            };

            AddGestureRecognizer(target, tap);
        }
    }
}
