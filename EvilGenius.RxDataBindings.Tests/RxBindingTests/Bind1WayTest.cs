using EvilGenius.RxDataBindings.Bindings;
using EvilGenius.RxDataBindings.Tests.Proxies;
using EvilGenius.RxDataBindings.Tests.Screens;
using EvilGenius.RxDataBindings.Tests.TargetObjects;
using EvilGenius.RxDataBindings.Tests.ValueConverters;
using EvilGenius.RxDataBindings.Tests.ViewModels;
using EvilGenius.RxDataBindings.Utils;
using NUnit.Framework;
using System;

namespace EvilGenius.RxDataBindings.Tests.RxBindingTests
{
    [TestFixture]
    public class Bind1WayTest
    {
        private BindingMode _mode = BindingMode.OneWay;
        
        /// <summary>
        /// Table case № 1 (see Docs/BindingTable.md)
        /// ValueAcceptorTargetProxy <- IReadonlyProperty
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptor_IReadOnlyProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<Label, ViewModelWithRxProps>();
            screen.SetBindings((label, vm, disposableBag) 
                => new RxBinding<string>(new LabelSetterTargetProxy(label), vm.ReadOnlyStrProperty, _mode, null, null).AddToCompositeDisposable(disposableBag));
            
            var vm = screen.ViewModel;
            
            Assert.IsTrue(vm.ReadOnlyStrProperty.Value == ViewModelWithRxProps._default_ReadOnly_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_ReadOnly_Str_Val);

            var newVal = "__newVal";

            //act
            vm.SetStrProperty(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 1 (see Docs/BindingTable.md) with converter
        /// ValueAcceptorTargetProxy <- IReadonlyProperty
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptor_IReadOnlyProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTarget<Label, ViewModelWithRxProps>();
            screen.SetBindings((label, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new LabelSetterTargetProxy(label), vm.ReadOnlyEnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.ReadOnlyEnumProperty.Value == ViewModelWithRxProps._default_ReadOnly_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_ReadOnly_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.SetEnumProperty(EnumModel.Three);

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }

        /// <summary>
        /// Table case № 2 (see Docs/BindingTable.md)
        /// ValueAcceptorTargetProxy <- IProperty
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptor_IProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<Label, ViewModelWithRxProps>();
            screen.SetBindings((label, vm, disposableBag)
                => new RxBinding<string>(new LabelSetterTargetProxy(label), vm.StrProperty, _mode, null, null).AddToCompositeDisposable(disposableBag));
            
            var vm = screen.ViewModel;


            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            vm.StrProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 2 (see Docs/BindingTable.md)
        /// ValueAcceptorTargetProxy <- IProperty with converter
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptor_IProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTarget<Label, ViewModelWithRxProps>();
            screen.SetBindings((label, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new LabelSetterTargetProxy(label), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;


            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.EnumProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }

        /// <summary>
        /// Table case № 5 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IReadonlyProperty
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptorProvider_IReadOnlyProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewTargetProxy(tv), vm.ReadOnlyStrProperty, _mode, null, null).AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.ReadOnlyStrProperty.Value == ViewModelWithRxProps._default_ReadOnly_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_ReadOnly_Str_Val);

            var newVal = "__newVal";

            //act
            vm.SetStrProperty(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 5 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IReadonlyProperty with converter
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptorProvider_IReadOnlyProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewTargetProxy(tv), vm.ReadOnlyEnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.ReadOnlyEnumProperty.Value == ViewModelWithRxProps._default_ReadOnly_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_ReadOnly_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.SetEnumProperty(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptorProvider_IProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(new TextViewTargetProxy(tv), vm.StrProperty, _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            vm.StrProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 6 (see Docs/BindingTable.md)
        /// ValueAcceptorProviderTargetProxy <- IProperty  with converter
        /// </summary>
        [Test]
        public void BindOneWay_ValAcceptorProvider_IProp_WithConverter()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(new TextViewTargetProxy(tv), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.EnumProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }

        /// <summary>
        /// Table case № 8 (see Docs/BindingTable.md)
        /// IPropertySetterProxy <- IReadOnlyProperty
        /// </summary>
        [Test]
        public void BindOneWay_PropSet_IReadonlyProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(PropertyInfoExtensions.ToPropertySetterProxy(tv => tv.Text, tv), vm.ReadOnlyStrProperty, _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.ReadOnlyStrProperty.Value == ViewModelWithRxProps._default_ReadOnly_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_ReadOnly_Str_Val);

            var newVal = "__newVal";

            //act
            vm.SetStrProperty(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 8 (see Docs/BindingTable.md)
        /// IPropertySetterProxy <- IReadOnlyProperty with conversion
        /// </summary>
        [Test]
        public void BindOneWay_PropSet_IReadonlyProp_WithConversion()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(PropertyInfoExtensions.ToPropertySetterProxy(tv => tv.Text, tv), vm.ReadOnlyEnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.ReadOnlyEnumProperty.Value == ViewModelWithRxProps._default_ReadOnly_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_ReadOnly_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.SetEnumProperty(newVal);

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }

        /// <summary>
        /// Table case № 9 (see Docs/BindingTable.md)
        /// IPropertySetterProxy <- IProperty
        /// </summary>
        [Test]
        public void BindOneWay_PropSet_IProp()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string>(PropertyInfoExtensions.ToPropertySetterProxy(tv => tv.Text, tv), vm.StrProperty, _mode, null, null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.StrProperty.Value == ViewModelWithRxProps._default_Str_Val);
            Assert.IsTrue(screen.Target.Text == ViewModelWithRxProps._default_Str_Val);

            var newVal = "__newVal";

            //act
            vm.StrProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == newVal);
        }

        /// <summary>
        /// Table case № 9 (see Docs/BindingTable.md)
        /// IPropertySetterProxy <- IProperty with conversion
        /// </summary>
        [Test]
        public void BindOneWay_PropSet_IProp_WithConversion()
        {
            //arrange
            using var screen = new ScreenWithTarget<TextView, ViewModelWithRxProps>();
            screen.SetBindings((tv, vm, disposableBag)
                => new RxBinding<string, EnumModel>(PropertyInfoExtensions.ToPropertySetterProxy(tv => tv.Text, tv), vm.EnumProperty, _mode, new EnumModelToStringConverter(), null)
                .AddToCompositeDisposable(disposableBag));

            var vm = screen.ViewModel;

            Assert.IsTrue(vm.EnumProperty.Value == ViewModelWithRxProps._default_Enum_Val);
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(ViewModelWithRxProps._default_Enum_Val));

            var newVal = EnumModel.Three;

            //act
            vm.EnumProperty.Value = newVal;

            //assert
            Assert.IsTrue(screen.Target.Text == EnumModelToStringConverter.EnumModelToString(newVal));
        }
    }
}
