using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using System.Collections.Generic;
using System.Linq;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class NumberPickerDisplayedValuesTargetProxy : ValueAcceptorAndroidTargetProxy<NumberPicker, IEnumerable<string>>
    {
        public NumberPickerDisplayedValuesTargetProxy(NumberPicker target) : base(target) { }

        protected override void AcceptValue(IEnumerable<string> value)
        {
            if (Target == null)
                return;

            if (Target.MaxValue == 0)
                Target.MaxValue = value?.Count() - 1 ?? 0;
            Target.SetDisplayedValues(value?.ToArray());
            Target.Invalidate();
        }
    }
}