using Android.Widget;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewDrawableTargetProxy : ImageViewDrawableBaseTargetProxy<int>
    {
        public ImageViewDrawableTargetProxy(ImageView target) : base(target) => Target = target;

        protected override void AcceptValue(int value) => AcceptValueCore(value);
    }
}