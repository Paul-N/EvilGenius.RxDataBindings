using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIPageControlCurrentPageTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UIPageControl, int>
    {
        public UIPageControlCurrentPageTargetProxy(UIPageControl target) : base(target) => target.ValueChanged += OnValueChanged;

        private void OnValueChanged(object sender, EventArgs e) => ProvideValue((int)Target.CurrentPage);

        protected override void AcceptValue(int value) => Target.CurrentPage = value;

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.ValueChanged -= OnValueChanged;

            base.Dispose(disposing);
        }
    }
}