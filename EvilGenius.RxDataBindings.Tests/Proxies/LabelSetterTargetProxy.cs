using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;

namespace EvilGenius.RxDataBindings.Tests.Proxies
{
    internal class LabelSetterTargetProxy : ValueAcceptorTargetProxy<string>
    {
        private Label _label;

        protected override void AcceptValue(string value) => _label.Text = value;

        public LabelSetterTargetProxy(Label label)
        {
            _label = label;
        }

        protected override void Dispose(bool disposing)
        {
            _label = null;
            base.Dispose(disposing);
        }
    }
}
