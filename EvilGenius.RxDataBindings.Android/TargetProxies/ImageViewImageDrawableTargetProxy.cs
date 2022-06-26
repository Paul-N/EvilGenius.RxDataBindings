using Android.Graphics.Drawables;
using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewImageDrawableTargetProxy : ValueAcceptorAndroidTargetProxy<ImageView, Drawable>
    {
        public ImageViewImageDrawableTargetProxy(ImageView target) : base(target) { }

        protected override void AcceptValue(Drawable value)
        {
            if (Target != null)
                Target.SetImageDrawable(value);
        }
    }
}