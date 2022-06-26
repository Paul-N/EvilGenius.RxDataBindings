using Android.Widget;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewResourceNameTargetProxy : ImageViewTargetProxy<int>
	{
		public ImageViewResourceNameTargetProxy(ImageView imageView) : base(imageView) { }

        protected override void AcceptValue(int id) => Target.SetImageResource(id);
	}
}