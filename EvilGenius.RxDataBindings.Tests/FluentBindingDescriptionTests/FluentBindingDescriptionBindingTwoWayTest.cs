using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using EvilGenius.RxDataBindings.Tests.ValueConverters;
using EvilGenius.RxDataBindings.Tests.ViewModels;
using NUnit.Framework;
using System;

namespace EvilGenius.RxDataBindings.Tests.FluentBindingDescriptionTests
{
    [TestFixture]
    public class FluentBindingDescriptionBindingTwoWayTest
    {
        private class Screen : ScreenWithTextView<ViewModelWithRxProps>
        {
            protected override void SetBindings()
            {
                Target.Bind<TextView, EnumModel, string>().For(v => v.BindText()).To(ViewModel.EnumProperty).WithConversion(new EnumModelToStringConverter()).TwoWay()
                    .Apply().AddToCompositeDisposable(_disposableBag);
            }
        }


        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty  with converter
        /// </summary>
        [Test]
        public void FluentDescr_ValAcceptorProvider_IProp_WithConverter()
        {
            //arrange
            using var screen = new Screen();

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
