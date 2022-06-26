using EvilGenius.RxDataBindings.Properties;

namespace EvilGenius.RxDataBindings.Tests.ViewModels
{
    internal class ViewModelWithRxProps
    {
        public const string _default_ReadOnly_Str_Val = "__defaultReadOnlyStrVal";
        public const string _default_Str_Val = "__defaultStrVal";

        public const EnumModel _default_ReadOnly_Enum_Val = EnumModel.One;
        public const EnumModel _default_Enum_Val = EnumModel.Two;

        private IPropertySetter<string> _oneWayStrPropertySetter;

        private IPropertySetter<EnumModel> _oneWayEnumPropertySetter;

        public IReadonlyProperty<string> ReadOnlyStrProperty { get; private set; }

        public IProperty<string> StrProperty { get; private set; }

        public IReadonlyProperty<EnumModel> ReadOnlyEnumProperty { get; private set; }

        public IProperty<EnumModel> EnumProperty { get; private set; }

        public ViewModelWithRxProps()
        {
            ReadOnlyStrProperty = new ReadonlyProperty<string>(ref _oneWayStrPropertySetter, _default_ReadOnly_Str_Val);
            StrProperty = new Property<string>(_default_Str_Val);
            ReadOnlyEnumProperty = new ReadonlyProperty<EnumModel>(ref _oneWayEnumPropertySetter, _default_ReadOnly_Enum_Val);
            EnumProperty = new Property<EnumModel>(_default_Enum_Val);
        }

        public void SetStrProperty(string str)
        {
            _oneWayStrPropertySetter.SetValue(str, isSilently: false);
        }

        public void SetEnumProperty(EnumModel model)
        {
            _oneWayEnumPropertySetter.SetValue(model, isSilently: false);
        }
    }
}
