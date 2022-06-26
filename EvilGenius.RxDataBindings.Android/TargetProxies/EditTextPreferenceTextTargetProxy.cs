using Android.Preferences;
using OneOf;
using JavaObject = Java.Lang.Object;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class EditTextPreferenceTextTargetProxy : PreferenceValueBaseTargetProxy<string>
    {
        public EditTextPreferenceTextTargetProxy(EditTextPreference target) : base(target) { }

        protected override void AcceptValue(OneOf<JavaObject, string> value)
        {
            if(value.IsT1 && Target is EditTextPreference editTextPreference)
                editTextPreference.Text = value.AsT1;
        }
    }
}