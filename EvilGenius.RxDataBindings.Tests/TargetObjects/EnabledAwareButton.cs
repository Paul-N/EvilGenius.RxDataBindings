using System;

namespace EvilGenius.RxDataBindings.Tests.TargetObjects
{
    internal class EnabledAwareButton : EnabledAwareView, IClickable
    {
        public event EventHandler OnClick;

        public void Click()
        {
            if(IsEnabled)
                OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
