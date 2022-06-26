using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using AndroidUri = Android.Net.Uri;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class VideoViewUriTargetProxy : ValueAcceptorAndroidTargetProxy<VideoView, string>
    {
        public VideoViewUriTargetProxy(VideoView target) : base(target) { }

        protected override void AcceptValue(string uri)
        {
            if(Target != null && !string.IsNullOrWhiteSpace(uri))
                Target.SetVideoURI(AndroidUri.Parse(uri));
        }
    }
}