using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class SearchViewQueryTextTargetProxy : ValueAcceptorProviderAndroidTargetProxy<SearchView, string>
    {
        public SearchViewQueryTextTargetProxy(SearchView target) : base(target) => Target.QueryTextChange += OnQueryTextChange;

        private void OnQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e) => ProvideValue(Target.Query);

        protected override void AcceptValue(string value) => Target.SetQuery(value, true);

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
                Target.QueryTextChange -= OnQueryTextChange;

            base.Dispose(disposing);
        }
    }
}