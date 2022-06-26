using EvilGenius.RxDataBindings.iOS.Utils;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIDatePickerMinMaxTargetProxy : BaseUIDatePickerTargetProxy<DateTime>
    {
        private enum DateKind { Min, Max }

        private DateKind _dateKind = DateKind.Min;

        public UIDatePickerMinMaxTargetProxy(UIDatePicker target, string propertyName) : base(target, propertyName)
        {
            if (propertyName == nameof(UIDatePicker.Date))
                throw new ArgumentException($"This binding cannot be used with the {nameof(UIDatePicker.Date)} property as the target.");

            if (propertyName == nameof(UIDatePicker.MaximumDate))
                _dateKind = DateKind.Max;
            else if (propertyName == nameof(UIDatePicker.MinimumDate))
                _dateKind = DateKind.Min;
            else throw new ArgumentException($"{propertyName} can not be used with this target proxy.");
        }

        protected override DateTime GetValueFrom(UIDatePicker view)
        {
            // This method should never be called.
            throw new NotImplementedException();
        }

        protected override void AcceptValue(DateTime value)
        {
            var valueUtc = ToUtcTime(value);
            var valueNSDate = valueUtc.ToNSDate();

            if (_dateKind == DateKind.Min)
                Target.MinimumDate = valueNSDate;
            else if(_dateKind == DateKind.Max)
                Target.MaximumDate = valueNSDate;
        }
    }
}