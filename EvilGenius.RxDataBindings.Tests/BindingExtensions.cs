using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using EvilGenius.RxDataBindings.Tests.Proxies;

namespace EvilGenius.RxDataBindings.Tests
{
    internal static class BindingExtensions
    {
        public static CommandTargetProxy BindCommand(this Button simpleStrTarget) => new ButtonTargetProxy(simpleStrTarget);

        public static CommandTargetProxy BindCommandCanExecuteAware(this EnabledAwareButton enabledAwareButton) => new EnabledAwareButtonTargetProxy(enabledAwareButton);

        public static CommandTargetProxy BindCommand(this ClickableTextView simpleStrTarget) => new ClickableTextViewCommandProxy(simpleStrTarget);

        public static ITargetProxy BindText(this ClickableTextView simpleStrTarget) => new ClickableTextViewGetterSetterTargetProxy(simpleStrTarget);

        public static ValueAcceptorProviderTargetProxy<string> BindText(this TextView textView) => new TextViewTargetProxy(textView);
    }
}
