using EvilGenius.RxDataBindings.Proxies;
using System;
using JavaObject = Java.Lang.Object;

namespace EvilGenius.RxDataBindings.Android.TargetProxies.Base
{
    public class CommandAndroidTargetProxy<TTarget> : CommandTargetProxy where TTarget : JavaObject
    {
        protected TTarget Target { get; set; }

        public CommandAndroidTargetProxy(TTarget target) 
            => Target = target ?? throw new ArgumentNullException(nameof(target));

        protected override void Dispose(bool disposing)
        {
            Target = null;
            base.Dispose(disposing);
        }
    }
}