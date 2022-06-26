using System;

namespace EvilGenius.RxDataBindings.Tests.TargetObjects
{
    internal class ClickableTextView
    {

        //let's suppose x, y is coords of the click
        public event EventHandler<ValueEventArgs<(int, int)>> OnClicked;

        public event EventHandler<ValueEventArgs<string>> OnTextChanged;

        private string _text;

        private Random _rand = new Random(100);

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnTextChanged?.Invoke(this, new ValueEventArgs<string>(value));
            }
        }

        public bool IsEnabled { get; set; } = true;

        public void Click()
        {
            if (IsEnabled)
                OnClicked?.Invoke(this, new ValueEventArgs<(int, int)>((_rand.Next(), _rand.Next())));
        }
    }
}
