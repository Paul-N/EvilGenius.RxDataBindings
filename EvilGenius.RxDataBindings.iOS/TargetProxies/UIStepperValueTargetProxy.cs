using EvilGenius.RxDataBindings.Proxies;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIStepperValueTargetProxy : ValueAcceptorProviderTargetProxy<double>
    {
        private UIStepper _target;

        public UIStepperValueTargetProxy(UIStepper target)
        {
            _target = target;
            _target.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_target != null)
                ProvideValue(_target.Value);
        }

        protected override void AcceptValue(double value)
        {
            if (_target != null)
                _target.Value = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (_target != null)
                _target.ValueChanged -= OnValueChanged;

            _target = null;

            base.Dispose(disposing);
        }
    }
}