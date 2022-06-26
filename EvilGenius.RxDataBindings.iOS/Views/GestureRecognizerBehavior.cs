using System;
using System.Reactive.Disposables;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.Views
{
    public class GestureRecognizerBehavior : UIGestureRecognizerDelegate
    {
        private IDisposable _weakDlgDisposable;
        private IDisposable _recognizerDisposable;

        protected void AddGestureRecognizer(UIView target, UIGestureRecognizer tap)
        {
            if (!target.UserInteractionEnabled)
                target.UserInteractionEnabled = true;

            if (target is UITextField && tap is UITapGestureRecognizer)
            {
                tap.WeakDelegate = this;
                _weakDlgDisposable = Disposable.Create(() => tap.WeakDelegate = null);
            }

            target.AddGestureRecognizer(tap);
            _recognizerDisposable = Disposable.Create(() => target.RemoveGestureRecognizer(tap));
        }

        public override bool ShouldBeRequiredToFailBy(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            _recognizerDisposable?.Dispose();
            _recognizerDisposable = null;

            _weakDlgDisposable?.Dispose();
            _weakDlgDisposable = null;

            base.Dispose(disposing);
        }
    }

    public abstract class GestureRecognizerBehavior<T> : GestureRecognizerBehavior
    {
        protected virtual void HandleGesture(T gesture)
        {
        }
    }
}
