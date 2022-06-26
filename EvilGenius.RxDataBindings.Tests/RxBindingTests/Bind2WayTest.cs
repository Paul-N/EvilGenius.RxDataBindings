using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Proxies;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.ValueConverters;
using EvilGenius.RxDataBindings.Tests.ViewModels;
using NUnit.Framework;
using System;

namespace EvilGenius.RxDataBindings.Tests.RxBindingTests
{
    [TestFixture]
    public class Bind2WayTest
    {
        private BindingMode _mode = BindingMode.TwoWay;

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty
        /// </summary>
        [Test]
        public void BindTwoWay_ValAcceptorProvider_IProp()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewTargetProxy(tv), vm.StrProperty, _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            screen.InputNewText(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty.Value == newVal);

            newVal = "__newVal2";

            //act
            vm.StrProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty.Value == newVal);
        }

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty  with converter
        /// </summary>
        [Test]
        public void BindTwoWay_ValAcceptorProvider_IProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewTargetProxy(tv), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);

            var newVal = EnumModelToStringConverter.GetDataPair(3);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty.Value == newVal.enumModel);

            newVal = EnumModelToStringConverter.GetDataPair(4);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty.Value == newVal.enumModel);
        }
    }
}
