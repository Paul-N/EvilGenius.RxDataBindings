using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UITextFieldShouldReturnTargetProxy : Command_iOSTargetProxy<UITextField>
    {
        public UITextFieldShouldReturnTargetProxy(UITextField target) : base(target)
        {
            Target.ShouldReturn = HandleShouldReturn;
        }

        private bool HandleShouldReturn(UITextField textField)
        {
            textField.ResignFirstResponder();
            FireCommand();
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.ShouldReturn = null;
            base.Dispose(disposing);
        }
    }
}