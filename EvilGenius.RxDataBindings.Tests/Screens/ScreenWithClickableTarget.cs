using EvilGenius.RxDataBindings.Tests.TargetObjects;

namespace EvilGenius.RxDataBindings.Tests.Screens
{
    internal class ScreenWithClickableTarget<TClickableTarget, TViewModel> : ScreenWithTarget<TClickableTarget, TViewModel>
        where TViewModel : new() where TClickableTarget : IClickable, new()
    {
        public void Click() => Target.Click();
    }
}
