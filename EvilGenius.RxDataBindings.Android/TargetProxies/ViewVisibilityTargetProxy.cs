using Android.Views;
using EvilGenius.RxDataBindings.Core;
using System;

namespace EvilGenius.RxDataBindings.Android.TargetProxies
{
    public class ViewVisibilityTargetProxy : ViewVisibilityBaseTargetProxy<Visibility>
    {
        public ViewVisibilityTargetProxy(View target) : base(target) { }

        protected override ViewStates GetViewState(Visibility value) => value switch
        {
            Visibility.Visible => ViewStates.Visible,
            Visibility.Hidden => ViewStates.Invisible,
            Visibility.Collapsed => ViewStates.Gone,
            _ => throw new InvalidOperationException(Target.Context.Resources.GetString(Resource.String.msg_unknown_visiblity)),
        };
    }
}