using Android.Views;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using System;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewClickTargetProxy : CommandAndroidTargetProxy<View>
    {
        public ViewClickTargetProxy(View target) : base(target) => Target.Click += OnViewClick;

        private void OnViewClick(object sender, EventArgs e) => FireCommand();

        public override void CanExecuteChanged(bool canExecute)
        {
            if(Target != null)
                Target.Enabled = canExecute;
        }

        protected override void Dispose(bool disposing)
        {
            Target.Click -= OnViewClick;
            base.Dispose(disposing);
        }
    }
}