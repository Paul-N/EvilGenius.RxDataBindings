using EvilGenius.RxDataBindings.Proxies;
using EvilGenius.RxDataBindings.Resources;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace EvilGenius.RxDataBindings.Utils;

public static class PropertyInfoExtensions
{
	public static Func<T, object> GetValueGetter<T>(this PropertyInfo propertyInfo)
	{
		if (typeof(T) != propertyInfo.DeclaringType)
			throw new ArgumentException();

		var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");

		var property = Expression.Property(instance, propertyInfo);

		var convert = Expression.TypeAs(property, typeof(object));

		return (Func<T, object>)Expression.Lambda(convert, instance).Compile();
	}

	public static Action<T, object> GetValueSetter<T>(this PropertyInfo propertyInfo)
	{
		if (typeof(T) != propertyInfo.DeclaringType)
			throw new ArgumentException();

		var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");

		var argument = Expression.Parameter(typeof(object), "a");

		var setterCall = Expression.Call(instance, propertyInfo.GetSetMethod(), Expression.Convert(argument, propertyInfo.PropertyType));

		return (Action<T, object>)Expression.Lambda(setterCall, instance, argument).Compile();
	}

	public static IPropertySetterProxy<TProperty> ToPropertySetterProxy<T, TProperty>(this Expression<Func<T, TProperty>> propSetter, T object_)
	{
		if (propSetter.Body is MemberExpression memberExpr)
		{

			var name = memberExpr.Member?.Name;
			var setter = typeof(T).GetProperty(name).GetValueSetter<T>();
			return new PropertySetterProxy<T, TProperty>(object_, setter);
		}
		else throw new ArgumentException(Strings.RxDataBindings_invalidPropertyExpression);
	}
}
