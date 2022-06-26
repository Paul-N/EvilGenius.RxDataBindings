using EvilGenius.RxDataBindings.Properties;

namespace RxMvvmDemo.Core.ViewModels
{
    public class MainViewModel
    {
        public int JustProperty { get; set; } = 13;

        public int OneWayToSourcePropertyToSet { get; set; }

        private IPropertySetter<string> _oneWayPropertySetter;

        public IReadonlyProperty<string> OneWayProperty { get; private set; }

        public MainViewModel()
        {
            OneWayProperty = new ReadonlyProperty<string>(ref _oneWayPropertySetter, "OneWayProperty init val");
        }

        public void SetOneWayProperty()
        {
            _oneWayPropertySetter?.SetValue("One way hello");
        }
    }
}
