using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UITextFieldTextFocusTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UITextField, string>
    {
        public UITextFieldTextFocusTargetProxy(UITextField target) : base(target) => target.EditingDidEnd += OnLostFocus;

        private void OnLostFocus(object sender, EventArgs e) => ProvideValue(Target.Text);

        protected override void AcceptValue(string value) => Target.Text = value ?? string.Empty;

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.EditingDidEnd -= OnLostFocus;
            base.Dispose(disposing);
        }
    }
}