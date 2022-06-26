using EvilGenius.RxDataBindings.iOS.Utils;
using Foundation;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIDatePickerDateTargetProxy : BaseUIDatePickerTargetProxy<DateTime>
    {
        public UIDatePickerDateTargetProxy(UIDatePicker target, string propertyName) : base(target, propertyName)
        {
        }

        protected override void AcceptValue(DateTime value)
        {
            // Convert from local DateTime (or default value) to universal NSDate based on system timezone.
            var valueUtc = ToUtcTime(value);
            var valueNSDate = valueUtc.ToNSDate();

            if (Target.MaximumDate != null && Target.MaximumDate.Compare(valueNSDate) == NSComparisonResult.Ascending)
                valueNSDate = Target.MaximumDate;
            else if (Target.MinimumDate != null && Target.MinimumDate.Compare(valueNSDate) == NSComparisonResult.Descending)
                valueNSDate = Target.MinimumDate;

            Target.Date = valueNSDate;
        }

        protected override DateTime GetValueFrom(UIDatePicker view)
        {
            // Convert from universal NSDate back to a local DateTime based on system timezone.
            var valueUtc = view.Date.ToDateTimeUtc();
            var valueLocal = ToLocalTime(valueUtc);
            return valueLocal;
        }
    }
}