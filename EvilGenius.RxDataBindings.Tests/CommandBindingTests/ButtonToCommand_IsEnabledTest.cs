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
    public class ButtonToCommand_IsEnabledTest
    {
        private class Screen : ScreenWithClickableTarget<EnabledAwareButton, ViewModel>
        {
            protected override void SetBindings()
                => new CommandBinding(new EnabledAwareButtonTargetProxy(Target), ViewModel.Command).AddToCompositeDisposable(this._disposableBag);
        }

        private class ViewModel
        {
            private bool _canExecuteCommand = false;

            public ICommand Command { get; private set; }

            public bool IsCommandExecuted { get; private set; } = false;

            public ViewModel() => Command = new Command(OnAction, () => _canExecuteCommand);

            private void OnAction() => IsCommandExecuted = true;

            public void AllowCommandExec()
            {
                _canExecuteCommand = true;
                (Command as Command).RaiseCanExecuteChanged();
            }
        }

        [Test]
        public void TryInvoke_ChangeIsEnabled_Invoke()
        {
            //arrange

            using var screen = new Screen();
            var vm = screen.ViewModel;

            Assert.IsFalse(vm.IsCommandExecuted);

            //act
            screen.Click();
            Assert.IsFalse(vm.IsCommandExecuted);
            vm.AllowCommandExec();
            screen.Click();

            //assert
            Assert.IsTrue(vm.IsCommandExecuted);
        }
    }
}