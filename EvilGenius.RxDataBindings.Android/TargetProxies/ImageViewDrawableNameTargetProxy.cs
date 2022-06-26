using Android.Content;
using Android.Widget;
using EvilGenius.Common.Logging;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ImageViewDrawableNameTargetProxy : ImageViewDrawableBaseTargetProxy<string>
    {
        private Context _context;

        public ImageViewDrawableNameTargetProxy(ImageView target, Context context) : base(target)
            => _context = context;

        protected override void AcceptValue(string value)
        {
            var resources = _context.Resources;
            var id = resources.GetIdentifier(value, "drawable", _context.PackageName);
            if (id == 0)
            {
                _logger.Log(LogLevel.Warn, LibTag.Tag, string.Format(_context.Resources.GetString(Resource.String.template_val_isnt_drawable), value));
                Target.SetImageDrawable(null);
                return;
            }

            base.AcceptValueCore(id);
        }
    }
}