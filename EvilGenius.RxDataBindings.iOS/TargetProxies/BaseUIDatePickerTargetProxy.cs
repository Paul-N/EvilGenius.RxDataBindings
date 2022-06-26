using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using EvilGenius.RxDataBindings.iOS.Utils;
using Foundation;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public abstract class BaseUIDatePickerTargetProxy<TProperty> : ValueAcceptorProvider_iOSTargetProxy<UIDatePicker, TProperty>
    {
        private NSTimeZone _systemTimeZone;

        public BaseUIDatePickerTargetProxy(UIDatePicker target, string propertyName) : base(target)
        {
            _systemTimeZone = NSTimeZone.SystemTimeZone;

            if (propertyName == nameof(UIDatePicker.Date) || propertyName == nameof(UIDatePicker.CountDownDuration))
                Target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e) => ProvideValue(GetValueFrom(Target));

        protected abstract TProperty GetValueFrom(UIDatePicker view);

        protected DateTime ToLocalTime(DateTime utc)
        {
            if (utc.Kind == DateTimeKind.Local)
                return utc;

            var local = utc.AddSeconds(_systemTimeZone.SecondsFromGMT(utc.ToNSDate())).WithKind(DateTimeKind.Local);

            return local;
        }

        protected DateTime ToUtcTime(DateTime local)
        {
            if (local.Kind == DateTimeKind.Utc)
                return local;

            var utc = local.AddSeconds(-_systemTimeZone.SecondsFromGMT(local.ToNSDate())).WithKind(DateTimeKind.Utc);

            return utc;
        }

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.ValueChanged -= OnValueChanged;

            _systemTimeZone = null;

            base.Dispose(disposing);
        }
    }
}