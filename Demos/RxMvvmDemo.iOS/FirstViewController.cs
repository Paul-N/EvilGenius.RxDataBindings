using System;
using System.Reactive.Disposables;
using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Core;
using EvilGenius.RxDataBindings.iOS;
using RxMvvmDemo.Core;
using RxMvvmDemo.Core.ViewModels;
using UIKit;

namespace RxMvvmDemo.iOS
{
    public partial class FirstViewController : UIViewController
    {
        private CompositeDisposable _disposableBag;

        public FirstViewModel ViewModel { get; set; }

        public FirstViewController(IntPtr handle) : base(handle)
        {
            ViewModel = new FirstViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            _disposableBag = new CompositeDisposable();
            //Tap bindings
            ViewToTap.Bind().For(v => v.BindTap()).To(ViewModel.ViewTapCommand).CommandParameter("Tap").Apply().AddToCompositeDisposable(_disposableBag);
            ViewToDoubleTap.Bind().For(v => v.BindDoubleTap()).To(ViewModel.ViewTapCommand).CommandParameter("DoubleTap").Apply().AddToCompositeDisposable(_disposableBag);
            ViewTo2FingerTap.Bind().For(v => v.BindTwoFingerTap()).To(ViewModel.ViewTapCommand).CommandParameter("TwoFingerTap").Apply().AddToCompositeDisposable(_disposableBag);
            LabelForTapInfo.Bind<UILabel, string>().For(v => v.BindText()).To(ViewModel.TapInfo).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            //Visibility and UISegmentedControl bindings
            VisibilitySelectionControl.Bind<UISegmentedControl, int>().For(v => v.BindSelectedSegment()).OneWayToSource().To((ViewModel, vm => vm.SelectedVisibility))
                .Apply().AddToCompositeDisposable(_disposableBag);
            ViewToVisibilitySet.Bind<UIView, Visibility>().For(v => v.BindVisibility()).To(ViewModel.ViewVisibility).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            //Bind IsVisible/UISwitch/UIActivityIndicatorView
            BoolInvertedConverter boolInvertedConverter = new BoolInvertedConverter();
            ViewToIsVisibleSet.Bind<UIView, bool>().For(v => v.BindVisible()).To(ViewModel.IsViewVisible).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            ViewToIsHiddenSet.Bind<UIView, bool>().For(v => v.BindHidden()).To(ViewModel.IsViewVisible).WithConversion(boolInvertedConverter).OneWay()
                .Apply().AddToCompositeDisposable(_disposableBag);
            ActivityIndicator.Bind<UIActivityIndicatorView, bool>().For(v => v.BindHidden()).To(ViewModel.IsViewVisible).WithConversion(boolInvertedConverter).OneWay()
                .Apply().AddToCompositeDisposable(_disposableBag);
            IsVisibleSwitch.Bind<UISwitch, bool>().For(v => v.BindOn()).To(ViewModel.IsViewVisible).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            IsHiddenSwitch.Bind<UISwitch, bool>().For(v => v.BindOn()).To(ViewModel.IsViewVisible).WithConversion(boolInvertedConverter).TwoWay()
                .Apply().AddToCompositeDisposable(_disposableBag);
            //Bind UIDateTimePickers
            var strConverter = new StringConverter();
            MniDatePicker.Bind<UIDatePicker, DateTime>().For(v => v.BindDate()).To(ViewModel.MinDate).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            MinDateLabel.Bind<UILabel, DateTime, string>().For(v => v.BindText()).To(ViewModel.MinDate).OneWay().WithConversion(strConverter, "Min Date:").Apply().AddToCompositeDisposable(_disposableBag);
            MaxDatePicker.Bind<UIDatePicker, DateTime>().For(v => v.BindDate()).To(ViewModel.MaxDate).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            MaxDateLabel.Bind<UILabel, DateTime, string>().For(v => v.BindText()).To(ViewModel.MaxDate).OneWay().WithConversion(strConverter, "Max Date:").Apply().AddToCompositeDisposable(_disposableBag);
            SelectedDatePicker.Bind<UIDatePicker, DateTime>().For(v => v.BindMinimumDate()).To(ViewModel.MinDate).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            SelectedDatePicker.Bind<UIDatePicker, DateTime>().For(v => v.BindMaximumDate()).To(ViewModel.MaxDate).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            SelectedDatePicker.Bind<UIDatePicker, DateTime>().For(v => v.BindDate()).To(ViewModel.SelectedDate).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            SelectedDateLabel.Bind<UILabel, DateTime, string>().For(v => v.BindText()).To(ViewModel.SelectedDate).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            SelectedTimeLabel.Bind<UILabel, DateTime, string>().For(v => v.BindText()).To(ViewModel.SelectedDate).OneWay().Apply().AddToCompositeDisposable(_disposableBag);

            //Bind UITextView UITextField
            TxtField.Bind<UITextField, string>().For(v => v.BindText()).To(ViewModel.TxtProp).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            TxtView.Bind<UITextView, string>().For(v => v.BindText()).To(ViewModel.TxtProp).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            TxtLbl.Bind<UILabel, string>().For(v => v.BindText()).To(ViewModel.TxtProp).OneWay().Apply().AddToCompositeDisposable(_disposableBag);

            //Bind Slider and Stepper
            Stepper.Bind<UIStepper, double>().For(v => v.BindValue()).To(ViewModel.StepperProp).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            StepperValLbl.Bind<UILabel, double, string>().For(v => v.BindText()).To(ViewModel.StepperProp).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
            Slider.Bind<UISlider, float>().For(v => v.BindValue()).To(ViewModel.SliderProp).TwoWay().Apply().AddToCompositeDisposable(_disposableBag);
            SliderValLbl.Bind<UILabel, float, string>().For(v => v.BindText()).To(ViewModel.SliderProp).OneWay().Apply().AddToCompositeDisposable(_disposableBag);
        }

        public override void ViewDidUnload()
        {
            _disposableBag?.Dispose();
            _disposableBag = null;
            base.ViewDidUnload();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ViewModel?.DisposeIfDisposable();
                ViewModel = null;
            }
            base.Dispose(disposing);
        }
    }
}
