using EvilGenius.RxDataBindings.Bindings;

namespace EvilGenius.RxDataBindings.Resources
{
    internal static class StringsExtensions
    {
        public static string ValueIsNot(string typeName) => string.Format(Strings.RxDataBindings_valueIsNot_template, typeName);

        public static string SrcPropertySupportOnly(BindingMode mode) => string.Format(Strings.RxDataBindings_src_prop_support_only_template, mode.ToString());
    }
}
