using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UISliderValueTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UISlider, float>
    {
        public UISliderValueTargetProxy(UISlider target) : base(target)
        {
            Target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if(Target != null)
                ProvideValue(Target.Value);
        }

        protected override void AcceptValue(float value)
        {
            if (Target != null)
                Target.Value = value;
        }

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.ValueChanged -= OnValueChanged;
            
            base.Dispose(disposing);
        }
    }
}