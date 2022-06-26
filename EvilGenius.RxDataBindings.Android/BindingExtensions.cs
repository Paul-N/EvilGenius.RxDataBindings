using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EvilGenius.RxDataBindings.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilGenius.RxDataBindings.Android
{
    public static class BindingExtensions
    {
        /// <summary>
        /// Bind view to the ViewModel property of another type
        /// </summary>
        /// <typeparam name="TView">View to bind</typeparam>
        /// <typeparam name="TSourceProperty">Source property of the ViewModel</typeparam>
        /// <typeparam name="TTargetProperty">Target property of the target view</typeparam>
        /// <param name="activity">Activity holding view in their view tree</param>
        /// <param name="resId">id of the view</param>
        /// <returns></returns>
        public static FluentBindingDescription<TView, TSourceProperty, TTargetProperty> Bind<TView, TSourceProperty, TTargetProperty>(this Activity activity, int resId) where TView : View
        {
            var view = activity.FindViewById<TView>(resId);
            return new FluentBindingDescription<TView, TSourceProperty, TTargetProperty>(view);
        }

        /// <summary>
        /// Bind Target view to the ViewModel with the same type of property
        /// </summary>
        /// <typeparam name="TView">View to bind</typeparam>
        /// <typeparam name="TProperty">Pproperty</typeparam>
        /// <param name="activity">Activity holding view in their view tree</param>
        /// <param name="resId">id of the view</param>
        /// <returns></returns>
        public static FluentBindingDescription<TView, TProperty> Bind<TView, TProperty>(this Activity activity, int resId) where TView : View
        {
            var view = activity.FindViewById<TView>(resId);
            return new FluentBindingDescription<TView, TProperty>(view);
        }

        /// <summary>
        /// Bind to command
        /// </summary>
        /// <typeparam name="TView">View to bind</typeparam>
        /// <param name="activity">Activity holding view in their view tree</param>
        /// <param name="resId">id of the view</param>
        /// <returns></returns>
        public static FluentBindingDescription<TView> Bind<TView>(this Activity activity, int resId) where TView : View
        {
            var view = activity.FindViewById<TView>(resId);
            return new FluentBindingDescription<TView>(view);
        }
    }
}