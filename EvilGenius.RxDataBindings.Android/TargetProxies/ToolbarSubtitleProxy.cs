using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using System;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    [Obsolete("Use Jetpack Toolbar instead")]
    public class ToolbarSubtitleProxy : ValueAcceptorAndroidTargetProxy<Toolbar, string>
    {
        [Obsolete("Use Jetpack Toolbar instead")]
        public ToolbarSubtitleProxy(Toolbar target) : base(target) { }

        protected override void AcceptValue(string value) => Target.Subtitle = value;
    }
}