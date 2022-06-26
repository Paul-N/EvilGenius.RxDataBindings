using EvilGenius.RxDataBindings.Bindings;
using Foundation;

namespace EvilGenius.RxDataBindings.iOS
{
    public static class BindingExtensions
    {
        /// <summary>
        /// Bind object to the ViewModel property of another type
        /// </summary>
        /// <typeparam name="TBindee">Type of the object to bind</typeparam>
        /// <typeparam name="TSourceProperty">Type of the source property of the ViewModel</typeparam>
        /// <typeparam name="TTargetProperty">Type of the target property of the target object</typeparam>
        /// <param name="bindee">Object to bind</param>
        /// <returns>Fluent description for Object <-> ViewModel binding</returns>
        public static FluentBindingDescription<TBindee, TSourceProperty, TTargetProperty> Bind<TBindee, TSourceProperty, TTargetProperty>(TBindee bindee) where TBindee : NSObject
            => new FluentBindingDescription<TBindee, TSourceProperty, TTargetProperty>(bindee);

        /// <summary>
        /// Bind Target view to the ViewModel with the same type of property
        /// </summary>
        /// <typeparam name="TBindee">Type of the object to bind</typeparam>
        /// <typeparam name="TProperty">Type of property on both sides</typeparam>
        /// <param name="bindee">Object to bind</param>
        /// <returns>Fluent description for Object <-> ViewModel binding</returns>
        public static FluentBindingDescription<TBindee, TProperty> Bind<TBindee, TProperty>(TBindee bindee) where TBindee : NSObject
            => new FluentBindingDescription<TBindee, TProperty>(bindee);

        /// <summary>
        /// Bind to command
        /// </summary>
        /// <typeparam name="TBindee">Type of the object to bind</typeparam>
        /// <param name="bindee">Object to bind</param>
        /// <returns>Fluent description for Object <-> ViewModel binding</returns>
        public static FluentBindingDescription<TBindee> Bind<TBindee>(TBindee bindee) where TBindee : NSObject
            => new FluentBindingDescription<TBindee>(bindee);
    }
}
