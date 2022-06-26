using EvilGenius.RxDataBindings.Proxies;
using Foundation;
using System;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies.Base
{
    public class ValueAcceptorProvider_iOSTargetProxy<TTarget, TProperty> : ValueAcceptorProviderTargetProxy<TProperty> where TTarget : NSObject
    {
        protected TTarget Target { get; set; }

        public ValueAcceptorProvider_iOSTargetProxy(TTarget target) 
            => Target = target ?? throw new ArgumentNullException(nameof(target));

        protected override void AcceptValue(TProperty value) { }

        protected override void Dispose(bool disposing)
        {
            Target = null;
            base.Dispose(disposing);
        }
    }
}