using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using System;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class ButtonTargetProxy : CommandTargetProxy
    {
        private Button _target;

        public ButtonTargetProxy(Button target)
        {
            _target = target;
            _target.OnClick += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e) => FireCommand();

        protected override void Dispose(bool disposing)
        {
            _target.OnClick -= OnButtonClick;
            _target = null;
            base.Dispose(disposing);
        }
    }
}
