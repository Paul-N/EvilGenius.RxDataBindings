using Android.Widget;
using EvilGenius.Common.Logging;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using EvilGenius.RxDataBindings.Android.Utils;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public abstract class ImageViewTargetProxy<TImgSource> : ValueAcceptorAndroidTargetProxy<ImageView, TImgSource>
    {
        internal ILogger _logger;

        public ImageViewTargetProxy(ImageView target) : base(target) => _logger = new Logger();

        protected override void Dispose(bool disposing)
        {
            _logger = null;
            base.Dispose(disposing);
        }
    }
}