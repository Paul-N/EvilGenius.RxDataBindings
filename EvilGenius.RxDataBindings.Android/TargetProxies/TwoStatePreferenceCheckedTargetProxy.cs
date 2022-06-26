using Android.Preferences;
using OneOf;
using JavaObject = Java.Lang.Object;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class TwoStatePreferenceCheckedTargetProxy : PreferenceValueBaseTargetProxy<bool>
    {
        public TwoStatePreferenceCheckedTargetProxy(TwoStatePreference target) : base(target) { }

        protected override void AcceptValue(OneOf<JavaObject, bool> value)
        {
            if (value.IsT1 && Target is TwoStatePreference twoStatePreference)
                twoStatePreference.Checked = value.AsT1;
        }
    }
}