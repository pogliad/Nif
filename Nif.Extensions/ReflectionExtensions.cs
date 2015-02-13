using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace Nif.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetMemberName<T, TResult>(this T type, Expression<Func<T, TResult>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression.IsNotNull());

            var me = expression.Body as MemberExpression;

            return me.IsNotNull() ? me.Member.Name : null;
        }

        public static void SetPropertyValue<T>(this object obj, string propertyName, T value)
        {
            Contract.Requires<ArgumentNullException>(obj.IsNotNull());
            Contract.Requires<ArgumentNullException>(propertyName.IsNotNullOrEmpty());

            var type = obj.GetType();

            if (type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) == null)
            {
                throw new ArgumentOutOfRangeException("propertyName", String.Format("Property {0} was not found in Type {1}", propertyName, obj.GetType().FullName));
            }

            type.InvokeMember(propertyName,
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.SetProperty
                | BindingFlags.Instance, null, obj, new object[] { value });
        }

        public static bool IsInheritedFromInterface<T>(this Type source)
        {
            var inheritedInterface = source.GetInterface(typeof(T).Name);

            return !inheritedInterface.IsNull();
        }
    }
}