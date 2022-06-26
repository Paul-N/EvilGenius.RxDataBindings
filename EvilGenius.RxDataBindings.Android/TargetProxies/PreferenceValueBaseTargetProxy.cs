using Android.Preferences;
using EvilGenius.Common.Logging;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using EvilGenius.RxDataBindings.Android.Utils;
using OneOf;
using JavaObject = Java.Lang.Object;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class PreferenceValueBaseTargetProxy<TPreferenceValue> : ValueAcceptorProviderAndroidTargetProxy<Preference, OneOf<JavaObject, TPreferenceValue>>
    {
        public PreferenceValueBaseTargetProxy(Preference target) : base(target) => target.PreferenceChange += OnPreferenceChange;

        private void OnPreferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
        {
            if (e.Preference == Target)
            {
                ProvideValue(e.NewValue);
                e.Handled = true;
            }
        }

        protected override void AcceptValue(OneOf<JavaObject, TPreferenceValue> value)
            => new Logger().Log(LogLevel.Warn, LibTag.Tag, Target.Context.Resources.GetString(Resource.String.msg_generic_preference_trg));

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.PreferenceChange -= OnPreferenceChange;
            
            base.Dispose(disposing);
        }
    }
}