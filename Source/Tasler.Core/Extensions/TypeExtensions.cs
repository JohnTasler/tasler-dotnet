using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tasler
{
    // TODO: NEEDS_UNIT_TESTS

    public static class TypeExtensions
    {
        public static bool Is<T>(this Type @this)
        {
            return typeof(T).IsAssignableFrom(@this);
        }

        public static bool Is(this Type @this, Type type)
        {
            return @this != null && type != null && type.IsAssignableFrom(@this);
        }

        public static bool Is(this object @this, Type type)
        {
            return @this != null && @this.GetType().Is(type);
        }

        public static bool HasCustomAttribute<T>(this Type @this, bool inherit)
        {
            return @this.GetCustomAttributes(typeof(T), inherit).Length != 0;
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this Type @this, bool inherit)
        {
            if (@this == null)
                return Enumerable.Empty<T>();

            return @this.GetCustomAttributes(typeof(T), inherit).Cast<T>();
        }

        public static IEnumerable<Type> GetFlattenedNestedTypes(this Type @this, BindingFlags bindingFlags)
        {
            for (var type = @this; type != null; type = type.BaseType)
                foreach (var nestedType in type.GetNestedTypes(bindingFlags))
                    yield return nestedType;
        }
    }
}
