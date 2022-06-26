using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIBarButtonItemTargetProxy : Command_iOSTargetProxy<UIBarButtonItem>
    {
        public UIBarButtonItemTargetProxy(UIBarButtonItem target) : base(target)
        {
            target.Clicked += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e) => FireCommand();

        public override void CanExecuteChanged(bool canExecute)
        {
            if (Target == null)
                return;

            Target.Enabled = canExecute;
        }

        protected override void Dispose(bool disposing)
        {
            if(Target != null)
                Target.Clicked -= OnClicked;

            base.Dispose(disposing);
        }
    }
}