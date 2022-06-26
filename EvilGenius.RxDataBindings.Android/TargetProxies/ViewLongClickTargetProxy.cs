using Android.Views;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using System;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewLongClickTargetProxy : CommandAndroidTargetProxy<View>
    {
        public ViewLongClickTargetProxy(View target) : base(target) => Target.LongClick += OnViewLongClick;

        private void OnViewLongClick(object sender, EventArgs e) => FireCommand();

        public override void CanExecuteChanged(bool canExecute)
        {
            if (Target != null)
                Target.Enabled = canExecute;
        }

        protected override void Dispose(bool disposing)
        {
            Target.Click -= OnViewLongClick;
            base.Dispose(disposing);
        }
    }
}