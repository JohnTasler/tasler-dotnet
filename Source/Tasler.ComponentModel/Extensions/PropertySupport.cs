using System;
using System.Linq.Expressions;
using System.Reflection;
using Tasler.ComponentModel.Properties;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// Provides methods to support conversion from a property expression to a property name string.
	/// </summary>
	public static class PropertySupport
	{
		/// <summary>
		/// Extracts the property name from a property expression.
		/// </summary>
		/// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
		/// <param name="propertyExpression">The property expression (e.g. p => p.PropertyName)</param>
		/// <returns>The name of the property.</returns>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="propertyExpression"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the expression is:<br/>
		///     Not a <see cref="MemberExpression"/><br/>
		///     The <see cref="MemberExpression"/> does not represent a property.<br/>
		///     Or, the property is static.
		/// </exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static string ExtractPropertyName<TResult>(Expression<Func<TResult>> propertyExpression)
		{
			ValidateArgument.IsNotNull(propertyExpression, nameof(propertyExpression));
			var memberExpression = ValidateArgument.IsOrIsDerivedFrom<MemberExpression>(propertyExpression.Body, nameof(propertyExpression));
			var propertyInfo = ValidateArgument.IsOrIsDerivedFrom<PropertyInfo>(memberExpression.Member, nameof(propertyExpression));

			var getMethod = propertyInfo.GetGetMethod(true);
			if (getMethod.IsStatic)
				throw new ArgumentException(Resources.PropertySupport_StaticExpression_Exception, "propertyExpression");

			return memberExpression.Member.Name;
		}

		/// <summary>
		/// Extracts the property name from a property expression.
		/// </summary>
		/// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
		/// <param name="propertyExpression">The property expression (e.g. p => p.PropertyName)</param>
		/// <returns>The name of the property.</returns>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="propertyExpression"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the expression is:<br/>
		///     Not a <see cref="MemberExpression"/><br/>
		///     The <see cref="MemberExpression"/> does not represent a property.<br/>
		///     Or, the property is static.
		/// </exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static string ExtractPropertyName<TSource, TResult>(Expression<Func<TSource, TResult>> propertyExpression)
		{
			ValidateArgument.IsNotNull(propertyExpression, nameof(propertyExpression));

			if (!(propertyExpression.Body is MemberExpression memberExpression))
			{
				var unaryExpression = ValidateArgument.IsOrIsDerivedFrom<UnaryExpression>(propertyExpression.Body, nameof(propertyExpression));
				memberExpression = ValidateArgument.IsOrIsDerivedFrom<MemberExpression>(unaryExpression.Operand, nameof(propertyExpression));
			}

			var propertyInfo = ValidateArgument.IsOrIsDerivedFrom<PropertyInfo>((propertyExpression.Body as MemberExpression).Member, nameof(propertyExpression));

			var getMethod = propertyInfo.GetGetMethod(true);
			if (getMethod.IsStatic)
				throw new ArgumentException(Resources.PropertySupport_StaticExpression_Exception, "propertyExpression");

			return memberExpression.Member.Name;
		}
	}
}
