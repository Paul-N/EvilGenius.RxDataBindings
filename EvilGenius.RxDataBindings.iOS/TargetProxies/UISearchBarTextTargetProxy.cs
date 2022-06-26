using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UISearchBarTextTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UISearchBar, string>
    {
        public UISearchBarTextTargetProxy(UISearchBar target) : base(target)
        {
            target.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, UISearchBarTextChangedEventArgs e) => ProvideValue(Target?.Text);

        protected override void AcceptValue(string value) => Target.Text = value;

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.TextChanged -= OnTextChanged;

            base.Dispose(disposing);
        }
    }
}