namespace EvilGenius.RxDataBindings.Tests.ViewModels
{
    internal class ViewModelWithPocoProps
    {
        public const string _default_Str_Val = "__defaultStrVal";

        public const EnumModel _default_Enum_Val = EnumModel.Two;

        public string StrProperty { get; set; }

        public EnumModel EnumProperty { get; set; }

        public ViewModelWithPocoProps()
        {
            StrProperty = _default_Str_Val;
            EnumProperty = _default_Enum_Val;
        }
    }
}
