using EvilGenius.RxDataBindings.Proxies;
using Foundation;
using System;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies.Base
{
    public class Command_iOSTargetProxy<TTarget> : CommandTargetProxy where TTarget : NSObject
    {
        protected TTarget Target { get; set; }

        public Command_iOSTargetProxy(TTarget target) 
            => Target = target ?? throw new ArgumentNullException(nameof(target));

        protected override void Dispose(bool disposing)
        {
            Target = null;
            base.Dispose(disposing);
        }
    }
}