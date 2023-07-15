namespace EvilGenius.RxDataBindings.Bindings;

public static class BindingExtensions
{
    public static FluentBindingDescription<TTarget> Bind<TTarget>(this TTarget target) => new FluentBindingDescription<TTarget>(target);

    public static FluentBindingDescription<TTarget, TSourceProperty, TTargetProperty> Bind<TTarget, TSourceProperty, TTargetProperty>(this TTarget target) 
        => new FluentBindingDescription<TTarget, TSourceProperty, TTargetProperty>(target);

    public static FluentBindingDescription<TTarget, TProperty> Bind<TTarget, TProperty>(this TTarget target)
        => new FluentBindingDescription<TTarget, TProperty>(target);
}
