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
    public class ButtonToCommand_WithParamTest
    {
        private class Screen : ScreenWithClickableTarget<Button, ViewModel>
        {
            protected override void SetBindings()
                => new CommandBinding(new ButtonTargetProxy(Target), ViewModel.Command, CommandParam.Two).AddToCompositeDisposable(this._disposableBag);
        }

        private enum CommandParam { One, Two }

        private class ViewModel
        {
            public ICommand Command { get; private set; }

            public CommandParam? SettedParam { get; private set; } = null;

            public ViewModel() => Command = new Command<CommandParam>(OnAction);

            private void OnAction(CommandParam param) => SettedParam = param;
        }

        [Test]
        public void InvokeByClickWithParam()
        {
            //arrange
            using var screen = new Screen();
            var vm = screen.ViewModel;

            Assert.IsNull(vm.SettedParam);

            //act
            screen.Click();

            //assert
            Assert.IsTrue(vm.SettedParam == CommandParam.Two);
        }
    }
}