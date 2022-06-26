using EvilGenius.RxDataBindings.Proxies;
using Foundation;
using System;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies.Base
{
    public class ValueAcceptor_iOSTargetProxy<TTarget, TProperty> : ValueAcceptorTargetProxy<TProperty> where TTarget : NSObject
    {
        protected TTarget Target { get; set; }
        
        public ValueAcceptor_iOSTargetProxy(TTarget target) 
            => Target = target ?? throw new ArgumentNullException(nameof(target));

        protected override void AcceptValue(TProperty value) { }

        protected override void Dispose(bool disposing)
        {
            Target = null;
            base.Dispose(disposing);
        }
    }
}