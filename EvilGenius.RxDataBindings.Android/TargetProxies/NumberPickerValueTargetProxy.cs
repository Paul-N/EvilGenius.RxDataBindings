using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class NumberPickerValueTargetProxy : ValueAcceptorProviderAndroidTargetProxy<NumberPicker, int>
    {
        public NumberPickerValueTargetProxy(NumberPicker target) : base(target)
        {
            target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            if (!e.OldVal.Equals(e.NewVal))
                ProvideValue(e.NewVal);
        }

        // this variable isn't used, but including this here prevents Mono from optimising the call out!
        private int JustForReflection
        {
            get { return Target.Value; }
            set { Target.Value = value; }
        }

        protected override void AcceptValue(int value)
        {
            if (Target == null)
                return;

            Target.Value = value;
        }

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.ValueChanged -= OnValueChanged;
            
            base.Dispose(disposing);
        }
    }
}