using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIDatePickerCountDownDurationTargetProxy : BaseUIDatePickerTargetProxy<double>
    {
        public UIDatePickerCountDownDurationTargetProxy(UIDatePicker target, string propertyName) : base(target, propertyName) { }

        protected override double GetValueFrom(UIDatePicker view) => view.CountDownDuration;

        protected override void AcceptValue(double value) => Target.CountDownDuration = value;
    }
}