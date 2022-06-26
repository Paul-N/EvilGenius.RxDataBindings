using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UISwitchOnTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UISwitch, bool>
    {
        public UISwitchOnTargetProxy(UISwitch target) : base(target)
        {
            Target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e) => ProvideValue(Target.On);

        protected override void AcceptValue(bool value) => Target.On = value;

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.ValueChanged -= OnValueChanged;

            base.Dispose(disposing);
        }
    }
}