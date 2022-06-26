using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class SeekBarProgressTargetProxy : ValueAcceptorProviderAndroidTargetProxy<SeekBar, int>
    {
        // this variable isn't used, but including this here prevents Mono from optimising the call out!
#pragma warning disable IDE0051 // Remove unused private members
        private int JustForReflection
        {
            get { return Target.Progress; }
            set { Target.Progress = value; }
        }
#pragma warning restore IDE0051 // Remove unused private members

        public SeekBarProgressTargetProxy(SeekBar target) : base(target) => Target.ProgressChanged += OnProgressChanged;

        private void OnProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e) => this.ProvideValue(e.Progress);

        protected override void AcceptValue(int value)
        {
            if (Target != null)
                Target.Progress = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.ProgressChanged -= OnProgressChanged;

            base.Dispose(disposing);
        }
    }
}