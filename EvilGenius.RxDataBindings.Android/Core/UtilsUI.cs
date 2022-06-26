using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Util;
using System.Collections.Generic;
using System.Linq;
using AndroidResources = Android.Content.Res.Resources;

namespace EvilGenius.RxDataBindings.Android.Core
{
    public static class UtilsUI
    {

#pragma warning disable CS0618 // Type or member is obsolete
        public static Color GetColorCompat(this Context context, int colorRes)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                return new Color(context.GetColor(colorRes));
            }
            else
            {
                return new Color(context.Resources.GetColor(colorRes));
            }
        }
#pragma warning restore CS0618 // Type or member is obsolete

        public static int DpToPx(this float dp) => DpToPxImpl(dp);

        public static int DpToPx(this int dp) => DpToPxImpl(dp);

        private static int DpToPxImpl(float dp)
            => (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, AndroidResources.System.DisplayMetrics);

        public static int SpToPx(this float sp)
            => (int)TypedValue.ApplyDimension(ComplexUnitType.Sp, sp, AndroidResources.System.DisplayMetrics);

        public static int DpToSp(this float dp)
            => (int)(DpToPx(dp) / AndroidResources.System.DisplayMetrics.ScaledDensity);

        public static Dictionary<int, int> CreateAttributeKeysSet(params int[] resIds)
        {
            if (resIds == null || !resIds.Any())
                return new Dictionary<int, int>();

            return resIds.Select((x, i) => (x, i))
                .ToDictionary((x) => x.x, (y) => y.i);
        }

        public static TypedArray ObtainStyledAttributes(this Context context, IAttributeSet attributeSet, Dictionary<int, int> attributeKeysSet)
        {
            if (context == null || attributeSet == null || attributeSet == null)
                return null;

            return context.ObtainStyledAttributes(attributeSet, attributeKeysSet.Keys.ToArray());
        }
    }
}