using EvilGenius.RxDataBindings.Core;
using EvilGenius.RxDataBindings.iOS.TargetProxies;
using EvilGenius.RxDataBindings.Proxies;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS
{
    public static class Platform_iOSPropertyProxyExtensions
    {
        public static CommandTargetProxy BindTouchUpInside(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.TouchUpInside);

        public static CommandTargetProxy BindValueChanged(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.ValueChanged);

        public static CommandTargetProxy BindTouchDown(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.TouchDown);

        public static CommandTargetProxy BindTouchDownRepeat(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.TouchDownRepeat);

        public static CommandTargetProxy BindTouchDragInside(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.TouchDragInside);

        public static CommandTargetProxy BindPrimaryActionTriggered(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.PrimaryActionTriggered);

        public static CommandTargetProxy BindEditingDidBegin(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.EditingDidBegin);

        public static CommandTargetProxy BindEditingChanged(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.EditingChanged);

        public static CommandTargetProxy BindEditingDidEnd(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.EditingDidEnd);

        public static CommandTargetProxy BindEditingDidEndOnExit(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.EditingDidEndOnExit);

        public static CommandTargetProxy BindAllTouchEvents(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.AllTouchEvents);

        public static CommandTargetProxy BindAllEditingEvents(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.AllEditingEvents);

        public static CommandTargetProxy BindAllEvents(this UIControl uiControl)
            => new UIControlTargetProxy(uiControl, UIControlEvent.AllEvents);

        public static ValueAcceptorTargetProxy<Visibility> BindVisibility(this UIView uiView, 
            NSLayoutConstraint widthConstraint = null, 
            NSLayoutConstraint heightConstraint = null)
            => new UIViewVisibilityTargetProxy(uiView, widthConstraint, heightConstraint);

        public static ValueAcceptorTargetProxy<bool> BindVisible(this UIView uiView)
            => new UIViewVisibleTargetProxy(uiView);

        public static ValueAcceptorTargetProxy<bool> BindHidden(this UIActivityIndicatorView uiActivityIndicatorView)
             => new UIActivityIndicatorViewHiddenTargetProxy(uiActivityIndicatorView);

        public static ValueAcceptorTargetProxy<bool> BindHidden(this UIView uiView)
            => new UIViewHiddenTargetProxy(uiView);

        public static ValueAcceptorProviderTargetProxy<float> BindValue(this UISlider uiSlider)
            => new UISliderValueTargetProxy(uiSlider);

        public static ValueAcceptorProviderTargetProxy<double> BindValue(this UIStepper uiStepper)
            => new UIStepperValueTargetProxy(uiStepper);

        public static ValueAcceptorProviderTargetProxy<int> BindSelectedSegment(this UISegmentedControl uiSegmentedControl)
            => new UISegmentedControlSelectedSegmentTargetProxy(uiSegmentedControl);

        public static ValueAcceptorProviderTargetProxy<DateTime> BindDate(this UIDatePicker uiDatePicker)
            => new UIDatePickerDateTargetProxy(uiDatePicker, nameof(UIDatePicker.Date));

        public static ValueAcceptorProviderTargetProxy<double> BindCountDownDuration(this UIDatePicker uiDatePicker)
            => new UIDatePickerCountDownDurationTargetProxy(uiDatePicker, nameof(UIDatePicker.CountDownDuration));

        public static ValueAcceptorProviderTargetProxy<DateTime> BindMinimumDate(this UIDatePicker uiDatePicker)
            => new UIDatePickerMinMaxTargetProxy(uiDatePicker, nameof(UIDatePicker.MinimumDate));

        public static ValueAcceptorProviderTargetProxy<DateTime> BindMaximumDate(this UIDatePicker uiDatePicker)
            => new UIDatePickerMinMaxTargetProxy(uiDatePicker, nameof(UIDatePicker.MaximumDate));

        public static CommandTargetProxy BindShouldReturn(this UITextField uiTextField)
            => new UITextFieldShouldReturnTargetProxy(uiTextField);

        public static ValueAcceptorProviderTargetProxy<TimeSpan> BindTime(this UIDatePicker uiDatePicker)
            => new UIDatePickerTimeTargetProxy(uiDatePicker, nameof(UIDatePicker.Date));

        public static ValueAcceptorTargetProxy<string> BindText(this UILabel uiLabel)
            => new UILabelTextTargetProxy(uiLabel);

        public static ValueAcceptorProviderTargetProxy<string> BindText(this UITextField uiTextField)
            => new UITextFieldTextTargetProxy(uiTextField);

        public static ValueAcceptorProviderTargetProxy<string> BindText(this UITextView uiTextView)
            => new UITextViewTextTargetProxy(uiTextView);

        public static ValueAcceptorTargetProxy<float> BindLayerBorderWidth(this UIView uiView)
            => new UIViewLayerBorderWidthTargetProxy(uiView);

        public static ValueAcceptorProviderTargetProxy<bool> BindOn(this UISwitch uiSwitch)
            => new UISwitchOnTargetProxy(uiSwitch);

        public static ValueAcceptorProviderTargetProxy<string> BindText(this UISearchBar uiSearchBar)
            => new UISearchBarTextTargetProxy(uiSearchBar);

        public static ValueAcceptorTargetProxy<string> BindTitle(this UIButton uiButton)
            => new UIButtonTitleTargetProxy(uiButton);

        public static ValueAcceptorTargetProxy<string> BindDisabledTitle(this UIButton uiButton)
            => new UIButtonTitleTargetProxy(uiButton, UIControlState.Disabled);

        public static ValueAcceptorTargetProxy<string> BindHighlightedTitle(this UIButton uiButton)
            => new UIButtonTitleTargetProxy(uiButton, UIControlState.Highlighted);

        public static ValueAcceptorTargetProxy<string> BindSelectedTitle(this UIButton uiButton)
            => new UIButtonTitleTargetProxy(uiButton, UIControlState.Selected);

        public static CommandTargetProxy BindTap(this UIView uiView)
            => new UIViewTapTargetProxy(uiView);

        public static CommandTargetProxy BindDoubleTap(this UIView uiView)
            => new UIViewTapTargetProxy(uiView, 2, 1);

        public static CommandTargetProxy BindTwoFingerTap(this UIView uiView)
            => new UIViewTapTargetProxy(uiView, 1, 2);

        public static ValueAcceptorProviderTargetProxy<string> BindTextFocus(this UITextField textField)
            => new UITextFieldTextFocusTargetProxy(textField);

        public static CommandTargetProxy BindClicked(this UIBarButtonItem uiBarButtonItem)
            => new UIBarButtonItemTargetProxy(uiBarButtonItem);

        public static ValueAcceptorProviderTargetProxy<int> BindCurrentPage(UIPageControl pageControl) 
            => new UIPageControlCurrentPageTargetProxy(pageControl);
    }
}