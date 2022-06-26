using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UITextFieldTextTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UITextField, string>
    {
        public UITextFieldTextTargetProxy(UITextField target) : base(target)
        {
            Target.EditingChanged += OnEditingTextField;
            Target.EditingDidEnd += OnEditingTextField;
        }

        private void OnEditingTextField(object sender, EventArgs e) => ProvideValue(Target?.Text);

        protected override void AcceptValue(string value) => Target.Text = value;

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
            {
                Target.EditingChanged -= OnEditingTextField;
                Target.EditingDidEnd -= OnEditingTextField; 
            }

            base.Dispose(disposing);
        }
    }
}