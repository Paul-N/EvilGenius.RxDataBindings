using Android.Views;
using EvilGenius.RxDataBindings.Android.Core;
using EvilGenius.RxDataBindings.Android.TargetProxies.Base;
using EvilGenius.RxDataBindings.Core;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewPaddingTargetProxy : ValueAcceptorAndroidTargetProxy<View, int>
    {
        private readonly Edges _edge;

        public ViewPaddingTargetProxy(View target, Edges edge) : base(target) => _edge = edge;

        protected override void AcceptValue(int value)
        {
            var pxPadding = value.DpToPx();

            var left = Target.PaddingLeft;
            var top = Target.PaddingTop;
            var right = Target.PaddingRight;
            var bottom = Target.PaddingBottom;

            switch (_edge)
            {
                case Edges.All:
                    Target.SetPadding(pxPadding, pxPadding, pxPadding, pxPadding);
                    break;
                case Edges.Left:
                    Target.SetPadding(pxPadding, top, right, bottom);
                    break;
                case Edges.Right:
                    Target.SetPadding(left, top, pxPadding, bottom);
                    break;
                case Edges.Top:
                    Target.SetPadding(left, pxPadding, right, bottom);
                    break;
                case Edges.Bottom:
                    Target.SetPadding(left, top, right, pxPadding);
                    break;
                case Edges.End:
                    Target.SetPadding(left, top, pxPadding, bottom);
                    break;
                case Edges.Start:
                    Target.SetPadding(pxPadding, top, right, bottom);
                    break;
            }
        }
    }
}