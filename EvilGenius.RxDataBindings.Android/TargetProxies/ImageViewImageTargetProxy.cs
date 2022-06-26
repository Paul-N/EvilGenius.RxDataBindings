using Android.Content;
using Android.Widget;
using EvilGenius.Common.Logging;
using System.IO;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewImageTargetProxy : BaseStreamImageViewTargetProxy<string>
    {
        private Context _context;

        public ImageViewImageTargetProxy(ImageView target, Context context) : base(target) 
            => _context = context;

        protected override Stream GetStream(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.Log(LogLevel.Warn, LibTag.Tag, _context.Resources.GetString(Resource.String.msg_empty_val_in_img_view_src));
                return null;
            }

            var drawableResourceName = GetImageAssetName(value);
            var assetStream = _context.Assets.Open(drawableResourceName);

            return assetStream;
        }

        private static string GetImageAssetName(string rawImage)
        {
            return rawImage.TrimStart('/');
        }

        protected override void Dispose(bool disposing)
        {
            _context = null;
            base.Dispose(disposing);
        }
    }
}