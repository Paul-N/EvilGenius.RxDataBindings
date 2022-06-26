using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using MvvmHelpers.Commands;
using NUnit.Framework;
using System;
using System.Windows.Input;

namespace EvilGenius.RxDataBindings.Tests.FluentBindingDescriptionTests
{
    [TestFixture]
    public class FluentBindingDescriptionCommandTest
    {
        private class Screen : ScreenWithClickableTarget<EnabledAwareButton, ViewModel>
        {
            protected override void SetBindings()
            {
                Target.Bind().For(t => t.BindCommandCanExecuteAware()).To(ViewModel.Command).CommandParameter(CommandParam.Two).Apply().AddToCompositeDisposable(_disposableBag);
            }
        }

        private enum CommandParam { One, Two }

        private class ViewModel
        {
            private bool _canExecuteCommand = false;

            public ICommand Command { get; private set; }

            public CommandParam? SettedParam { get; private set; } = null;

            public ViewModel() => Command = new Command<CommandParam>(OnAction, (param) => _canExecuteCommand);

            private void OnAction(CommandParam param) => SettedParam = param;

            public void AllowCommandExec()
            {
                _canExecuteCommand = true;
                (Command as Command).RaiseCanExecuteChanged();
            }
        }

        [Test]
        public void TryInvoke_ChangeIsEnabled_Invoke_WithParam()
        {
            //arrange

            using var screen = new Screen();
            var vm = screen.ViewModel;

            Assert.IsNull(vm.SettedParam);

            //act
            screen.Click();
            Assert.IsNull(vm.SettedParam);
            vm.AllowCommandExec();
            screen.Click();

            //assert
            Assert.IsTrue(vm.SettedParam == CommandParam.Two);
        }
    }
}
