using Android.Webkit;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class WebViewHtmlTargetProxy : ValueAcceptorAndroidTargetProxy<WebView, string>
    {
        public WebViewHtmlTargetProxy(WebView target) : base(target) { }

        protected override void AcceptValue(string html)
        {
            if (Target != null && html != null)
                Target.LoadData(html, "text/html; charset=utf-8", "UTF-8");
        }
    }
}