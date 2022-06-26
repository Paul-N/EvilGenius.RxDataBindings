using System;

namespace EvilGenius.RxDataBindings.Tests.TargetObjects
{
    internal class Button : View, IClickable
    {
        public event EventHandler OnClick;

        public void Click() => OnClick?.Invoke(this, EventArgs.Empty);
    }
}
