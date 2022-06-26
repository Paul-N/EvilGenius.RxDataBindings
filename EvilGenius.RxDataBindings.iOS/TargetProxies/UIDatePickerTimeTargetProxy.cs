using EvilGenius.RxDataBindings.iOS.Utils;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIDatePickerTimeTargetProxy : BaseUIDatePickerTargetProxy<TimeSpan>
    {
        public UIDatePickerTimeTargetProxy(UIDatePicker target, string propertyName) : base(target, propertyName) { }

        protected override TimeSpan GetValueFrom(UIDatePicker view)
        {
            // Convert from universal NSDate back to a local DateTime based on system timezone, and return its time of day.
            var valueUtc = Target.Date.ToDateTimeUtc();
            var valueLocal = ToLocalTime(valueUtc);
            return valueLocal.TimeOfDay;
        }

        protected override void AcceptValue(TimeSpan value)
        {
            if (value == default)
                value = TimeSpan.FromSeconds(0);

            var now = DateTime.Now;

            // Convert from local DateTime with the TimeSpan as its time of day to universal NSDate based on system timezone.

            var dateLocal = new DateTime(
                now.Year,
                now.Month,
                now.Day,
                value.Hours,
                value.Minutes,
                value.Seconds,
                DateTimeKind.Local);

            var dateUtc = ToUtcTime(dateLocal);
            var nsDate = dateUtc.ToNSDate();

            Target.Date = nsDate;
        }
    }
}