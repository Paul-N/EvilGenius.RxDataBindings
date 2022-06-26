using Android.Graphics;
using Android.Widget;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewBitmapTargetProxy : BaseImageViewTargetProxy<Bitmap>
    {
        public ImageViewBitmapTargetProxy(ImageView target) : base(target) { }

        protected override Bitmap GetBitmap(Bitmap value) => value;
    }
}