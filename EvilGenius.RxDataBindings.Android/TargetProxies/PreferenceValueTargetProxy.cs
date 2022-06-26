using Android.Preferences;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class PreferenceValueTargetProxy : PreferenceValueBaseTargetProxy<object>
    {
        public PreferenceValueTargetProxy(Preference target) : base(target) { }
    }
}