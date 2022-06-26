using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UISegmentedControlSelectedSegmentTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UISegmentedControl, int>
    {
        public UISegmentedControlSelectedSegmentTargetProxy(UISegmentedControl target) : base(target)
        {
            Target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e) => ProvideValue((int)Target.SelectedSegment);

        protected override void AcceptValue(int value) => Target.SelectedSegment = (nint)value;

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.ValueChanged -= OnValueChanged;

            base.Dispose(disposing);
        }
    }
}