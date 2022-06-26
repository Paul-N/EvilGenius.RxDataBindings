using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class RatingBarRatingTargetProxy : ValueAcceptorProviderAndroidTargetProxy<RatingBar, float>
    {
        public RatingBarRatingTargetProxy(RatingBar target) : base(target) => target.RatingBarChange += OnRatingBarChange;

        private void OnRatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e) => ProvideValue(Target.Rating);

        protected override void AcceptValue(float value)
        {
            if(Target != null)
                Target.Rating = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.RatingBarChange -= OnRatingBarChange;
            
            base.Dispose(disposing);
        }
    }
}