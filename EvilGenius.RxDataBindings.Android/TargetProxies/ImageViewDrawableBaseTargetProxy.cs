using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public abstract class ImageViewDrawableBaseTargetProxy<TImgSource> : ImageViewTargetProxy<TImgSource>
    {
        public ImageViewDrawableBaseTargetProxy(ImageView target) : base(target) { }

        protected Drawable GetDrawable(int id)
        {
            if (Target == null)
                return null;

            var context = Target.Context;
            Drawable drawable;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                drawable = context?.Resources?.GetDrawable(id, context.Theme);
            else
#pragma warning disable CS0618 // Type or member is obsolete
                drawable = context?.Resources?.GetDrawable(id);
#pragma warning restore CS0618 // Type or member is obsolete

            return drawable;
        }

        protected void AcceptValueCore(int value)
        {
            if (value == 0)
                Target?.SetImageDrawable(null);
            else
                Target?.SetImageDrawable(GetDrawable(value));
        }
    }
}