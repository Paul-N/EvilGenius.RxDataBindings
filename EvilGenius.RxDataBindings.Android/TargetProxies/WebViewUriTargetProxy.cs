using Android.Webkit;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class WebViewUriTargetProxy : ValueAcceptorAndroidTargetProxy<WebView, string>
    {
        public WebViewUriTargetProxy(WebView target) : base(target) { }

        protected override void AcceptValue(string uri)
        {
            if (Target != null && uri != null)
                Target.LoadUrl(uri);
        }
    }
}