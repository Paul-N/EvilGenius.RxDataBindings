using Android.Graphics;
using Android.Widget;
using EvilGenius.Common.Logging;
using System;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public abstract class BaseImageViewTargetProxy<TBitmapSource> : ImageViewTargetProxy<TBitmapSource>
    {
        public BaseImageViewTargetProxy(ImageView target) : base(target) { }

        protected abstract Bitmap GetBitmap(TBitmapSource value);

        protected override void AcceptValue(TBitmapSource value)
        {
            try
            {
                if (GetBitmap(value) is Bitmap bitmap)
                    SetImageBitmap(Target, bitmap);
                else
                    return;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, LibTag.Tag, ex.ToLongString());
                throw;
            }
        }

        protected virtual void SetImageBitmap(ImageView imageView, Bitmap bitmap)
        {
            imageView.SetImageBitmap(bitmap);
        }
    }
}