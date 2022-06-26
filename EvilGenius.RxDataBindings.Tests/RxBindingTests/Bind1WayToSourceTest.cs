using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Proxies;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.ValueConverters;
using EvilGenius.RxDataBindings.Tests.ViewModels;
using EvilGenius.RxDataBindings.Utils;
using NUnit.Framework;
using System;

namespace EvilGenius.RxDataBindings.Tests.RxBindingTests
{
    [TestFixture]
    public class Bind1WayToSourceTest
    {
        private BindingMode _mode = BindingMode.OneWayToSource;

        /// <summary>
        /// Table case № 3 (see Docs/BindingTable.md)
        /// ValueProviderTargetProxy -> IProperty
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValProvider_IProp()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewProviderTargetProxy(tv), vm.StrProperty, _mode, null, null).AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            screen.InputNewText(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty.Value == newVal);
        }

        /// <summary>
        /// Table case № 3 (see Docs/BindingTable.md)
        /// ValueProviderTargetProxy -> IProperty with converter
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValProvider_IProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewProviderTargetProxy(tv), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);

            var newVal = EnumModelToStringConverter.GetDataPair(3);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty.Value == newVal.enumModel);
        }

        /// <summary>
        /// Table case № 4 (see Docs/BindingTable.md)
        /// ValueProviderTargetProxy -> IPropertySetterProxy
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValProvider_PropSet()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithPocoProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewProviderTargetProxy(tv), PropertyInfoExtensions.ToPropertySetterProxy(vm => vm.StrProperty, vm), _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty == ViewModelWithPocoProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            screen.InputNewText(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty == newVal);
        }

        /// <summary>
        /// Table case № 4 (see Docs/BindingTable.md)
        /// ValueProviderTargetProxy -> IPropertySetterProxy with converter
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValProvider_PropSet_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithPocoProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewProviderTargetProxy(tv), PropertyInfoExtensions.ToPropertySetterProxy(vm => vm.EnumProperty, vm), _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty == ViewModelWithPocoProps._default_Enum_Val);

            var newVal = EnumModelToStringConverter.GetDataPair(3);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty == newVal.enumModel);
        }

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValAcceptorProvider_IProp()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewProviderTargetProxy(tv), vm.StrProperty, _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            screen.InputNewText(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty.Value == newVal);
        }

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty  with converter
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValAcceptorProvider_IProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewProviderTargetProxy(tv), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);

            var newVal = EnumModelToStringConverter.GetDataPair(3);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty.Value == newVal.enumModel);
        }

        /// <summary>
        /// Table case № 7 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy -> IPropertySetterProxy
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValAcceptorProvider_PropSet()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithPocoProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewTargetProxy(tv), PropertyInfoExtensions.ToPropertySetterProxy(vm => vm.StrProperty, vm), _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty == ViewModelWithPocoProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            screen.InputNewText(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
            Assert.IsTrue(vm.StrProperty == newVal);
        }

        /// <summary>
        /// Table case № 7 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy -> IPropertySetterProxy with converter
        /// </summary>
        [Test]
        public void BindOneWayToSrc_ValAcceptorProvider_PropSet_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTextView<ViewModelWithPocoProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewTargetProxy(tv), PropertyInfoExtensions.ToPropertySetterProxy(vm => vm.EnumProperty, vm), _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty == ViewModelWithPocoProps._default_Enum_Val);

            var newVal = EnumModelToStringConverter.GetDataPair(3);

            //act
            screen.InputNewText(newVal.str);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal.str);
            Assert.IsTrue(vm.EnumProperty == newVal.enumModel);
        }
    }
}
