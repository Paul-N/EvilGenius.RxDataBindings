using EvilGenius.RxDataBindings.Tests.TargetObjects;

namespace EvilGenius.RxDataBindings.Tests.Screens
{
    internal class ScreenWithTextView<TViewModel> : ScreenWithTarget<TextView, TViewModel> where TViewModel : new()
    {
        public void InputNewText(string userInput)
        {
            Target.Text = userInput;
        }
    }
}
