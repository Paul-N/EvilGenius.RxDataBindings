using Android.Preferences;
using OneOf;
using JavaObject = Java.Lang.Object;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ListPreferenceTargetProxy : PreferenceValueBaseTargetProxy<string>
    {
        public ListPreferenceTargetProxy(ListPreference target) : base(target) { }

        protected override void AcceptValue(OneOf<JavaObject, string> value)
        {
            if (value.IsT1 && Target is ListPreference listPreference)
                listPreference.Value = value.AsT1;
        }
    }
}