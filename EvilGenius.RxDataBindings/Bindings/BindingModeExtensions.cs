using System.Collections.Generic;
using System.Linq;

namespace EvilGenius.RxDataBindings.Bindings
{
    public static class BindingModeExtensions
    {
        public static IEnumerable<BindingMode> RxBindingModes => new BindingMode[] { BindingMode.OneWay, BindingMode.TwoWay, BindingMode.OneWayToSource };
        
        public static bool IsRxBindingMode(this BindingMode mode) => RxBindingModes.Contains(mode);
    }
}
