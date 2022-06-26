using Android.Views;
using EvilGenius.RxDataBindings.Android.Core;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using EvilGenius.RxDataBindings.Core;
using AndroidResources = global::Android.Content.Res.Resources;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewMarginTargetProxy : ValueAcceptorAndroidTargetProxy<View, int>
    {
        private readonly Edges _edge;

        public ViewMarginTargetProxy(View target, Edges edge) : base(target) => _edge = edge;

        protected override void AcceptValue(int dpMargin)
        {
            if (Target == null) return;

            var layoutParameters = Target.LayoutParameters as ViewGroup.MarginLayoutParams;
            if (layoutParameters == null) return;

            var pxMargin = dpMargin.DpToPx();

            switch (_edge)
            {
                case Edges.All:
                    layoutParameters.SetMargins(pxMargin, pxMargin, pxMargin, pxMargin);
                    break;
                case Edges.Left:
                    layoutParameters.LeftMargin = pxMargin;
                    break;
                case Edges.Right:
                    layoutParameters.RightMargin = pxMargin;
                    break;
                case Edges.Top:
                    layoutParameters.TopMargin = pxMargin;
                    break;
                case Edges.Bottom:
                    layoutParameters.BottomMargin = pxMargin;
                    break;
                case Edges.End:
                    layoutParameters.MarginEnd = pxMargin;
                    break;
                case Edges.Start:
                    layoutParameters.MarginStart = pxMargin;
                    break;
            }
        }
    }
}
