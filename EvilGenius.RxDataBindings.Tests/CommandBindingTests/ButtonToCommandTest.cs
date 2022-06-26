using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Proxies;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using MvvmHelpers.Commands;
using NUnit.Framework;
using System;
using System.Windows.Input;

namespace EvilGenius.RxDataBindings.Tests.CommandBindingTests
{
    [TestFixture]
    public class ButtonToCommandTest
    {

        private class Screen : ScreenWithClickableTarget<Button, ViewModel>
        {
            protected override void SetBindings() 
                => new CommandBinding(new ButtonTargetProxy(Target), ViewModel.Command).AddToCompositeDisposable(this._disposableBag);
        }

        private class ViewModel
        {
            public ICommand Command { get; private set; }

            public bool IsCommandInvoked { get; private set; } = false;

            public ViewModel() => Command = new Command(OnAction);

            private void OnAction() => IsCommandInvoked = true;
        }

        [Test]
        public void InvokeByClick()
        {
            //arrange
            using var screen = new Screen();
            var vm = screen.ViewModel;
            
            Assert.IsFalse(vm.IsCommandInvoked);

            //act
            screen.Click();

            //assert
            Assert.IsTrue(vm.IsCommandInvoked);
        }
    }
}