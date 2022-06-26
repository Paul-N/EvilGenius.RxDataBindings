namespace EvilGenius.RxDataBindings.Properties
{
    public interface IPropertySetter<T> : IPropertyRaiser
    {
        void SetValue(T value, bool isSilently = false);
        void SetValueSilently(T value);
    }
}