using System;

namespace EvilGenius.RxDataBindings.Tests.TargetObjects
{
    internal class TextView
    {

        public event EventHandler<ValueEventArgs<string>> OnTextChanged;

        private string _text;

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
    }
}
