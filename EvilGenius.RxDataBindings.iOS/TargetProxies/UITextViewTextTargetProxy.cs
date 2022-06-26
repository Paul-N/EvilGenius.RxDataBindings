using EvilGenius.RxDataBindings.iOS.TargetProxies.Base;
using EvilGenius.RxDataBindings.iOS.Utils;
using Foundation;
using System;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UITextViewTextTargetProxy : ValueAcceptorProvider_iOSTargetProxy<UITextView, string>
    {
        private IDisposable _onTextStorageDidProcessEditingSubscription;

        public UITextViewTextTargetProxy(UITextView target) : base(target)
        {
            var textStorage = target.LayoutManager?.TextStorage;

            var b = NSBundle.MainBundle; //TODO: remove

            if (textStorage == null)
            {
                var logger = new Logger();
                logger.Log(Common.Logging.LogLevel.Error, LibTag.Tag, $"Error - {nameof(NSTextStorage)} of {nameof(UITextView)} is null in {nameof(UITextViewTextTargetProxy)}");
            }
            else
                _onTextStorageDidProcessEditingSubscription = textStorage.SubscribeToEvent(
                    () => textStorage.DidProcessEditing += OnTextStorageDidProcessEditing,
                    () => textStorage.DidProcessEditing -= OnTextStorageDidProcessEditing);
        }

        private void OnTextStorageDidProcessEditing(object sender, NSTextStorageEventArgs e) => ProvideValue(Target?.Text);

        protected override void AcceptValue(string value) => Target.Text = value;

        protected override void Dispose(bool disposing)
        {
            _onTextStorageDidProcessEditingSubscription?.Dispose();
            _onTextStorageDidProcessEditingSubscription = null;
            base.Dispose(disposing);
        }
    }
}