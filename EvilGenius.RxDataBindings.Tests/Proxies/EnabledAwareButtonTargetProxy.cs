using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class EnabledAwareButtonTargetProxy : CommandTargetProxy
    {
        private EnabledAwareButton _target;

        public EnabledAwareButtonTargetProxy(EnabledAwareButton target)
        {
            _target = target;
            _target.OnClick += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e) => FireCommand();

        public override void CanExecuteChanged(bool canExecute) => _target.IsEnabled = canExecute;

        protected override void Dispose(bool disposing)
        {
            _target.OnClick -= OnButtonClick;
            _target = null;
            base.Dispose(disposing);
        }
    }
}
