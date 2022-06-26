using EvilGenius.Common.Logging;
using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using EvilGenius.RxDataBindings.iOS.Utils;
using System;
using System.Reactive.Disposables;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIControlTargetProxy : Command_iOSTargetProxy<UIControl>
    {
        private IDisposable _eventSubscription;

        public UIControlTargetProxy(UIControl target, UIControlEvent controlEvent) : base(target) => _eventSubscription = AddHandler(controlEvent);



        private IDisposable AddHandler(UIControlEvent controlEvent)
        {
            switch (controlEvent)
            {
                case UIControlEvent.TouchDown:
                    return Target.SubscribeToEvent(() => Target.TouchDown += OnControlEvent, () => Target.TouchDown -= OnControlEvent);
                case UIControlEvent.TouchDownRepeat:
                    return Target.SubscribeToEvent(() => Target.TouchDownRepeat += OnControlEvent, () => Target.TouchDownRepeat -= OnControlEvent);
                case UIControlEvent.TouchDragInside:
                    return Target.SubscribeToEvent(() => Target.TouchDragInside += OnControlEvent, () => Target.TouchDragInside -= OnControlEvent);
                case UIControlEvent.TouchUpInside:
                    return Target.SubscribeToEvent(() => Target.TouchUpInside += OnControlEvent, () => Target.TouchUpInside -= OnControlEvent);
                case UIControlEvent.ValueChanged:
                    return Target.SubscribeToEvent(() => Target.ValueChanged += OnControlEvent, () => Target.ValueChanged -= OnControlEvent);
                case UIControlEvent.PrimaryActionTriggered:
                    return Target.SubscribeToEvent(() => Target.PrimaryActionTriggered += OnControlEvent, () => Target.PrimaryActionTriggered -= OnControlEvent);
                case UIControlEvent.EditingDidBegin:
                    return Target.SubscribeToEvent(() => Target.EditingDidBegin += OnControlEvent, () => Target.EditingDidBegin -= OnControlEvent);
                case UIControlEvent.EditingChanged:
                    return Target.SubscribeToEvent(() => Target.EditingChanged += OnControlEvent, () => Target.EditingChanged -= OnControlEvent);
                case UIControlEvent.EditingDidEnd:
                    return Target.SubscribeToEvent(() => Target.EditingDidEnd += OnControlEvent, () => Target.EditingDidEnd -= OnControlEvent);
                case UIControlEvent.EditingDidEndOnExit:
                    return Target.SubscribeToEvent(() => Target.EditingDidEndOnExit += OnControlEvent, () => Target.EditingDidEndOnExit -= OnControlEvent);
                case UIControlEvent.AllTouchEvents:
                    return Target.SubscribeToEvent(() => Target.AllTouchEvents += OnControlEvent, () => Target.AllTouchEvents -= OnControlEvent);
                case UIControlEvent.AllEditingEvents:
                    return Target.SubscribeToEvent(() => Target.AllEditingEvents += OnControlEvent, () => Target.AllEditingEvents -= OnControlEvent);
                case UIControlEvent.AllEvents:
                    return Target.SubscribeToEvent(() => Target.AllEvents += OnControlEvent, () => Target.AllEvents -= OnControlEvent);
                default:
                    var logger = new Logger();
                    logger.Log(LogLevel.Error, LibTag.Tag, $"Error - Invalid {nameof(controlEvent)} in {nameof(UIControlTargetProxy)}");
                    return Disposable.Empty;
            }
        }

        private void OnControlEvent(object sender, EventArgs e) => FireCommand();

        public override void CanExecuteChanged(bool canExecute)
        {
            if(Target != null)
                Target.Enabled = canExecute;
        }

        protected override void Dispose(bool disposing)
        {
            _eventSubscription?.Dispose();
            _eventSubscription = null;
            base.Dispose(disposing);
        }
    }
}