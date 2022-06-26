using Android.Graphics;
using Android.Widget;
using System.IO;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public abstract class BaseStreamImageViewTargetProxy<TBitmapSource> : BaseImageViewTargetProxy<TBitmapSource>
    {
        protected BaseStreamImageViewTargetProxy(ImageView target) : base(target) { }

        protected override Bitmap GetBitmap(TBitmapSource value)
        {
            var assetStream = GetStream(value);
            if (assetStream == null)
            {
                return null;
            }

            var options = new BitmapFactory.Options { InPurgeable = true };
            return BitmapFactory.DecodeStream(assetStream, null, options);
        }

        protected abstract Stream GetStream(TBitmapSource value);
    }
}