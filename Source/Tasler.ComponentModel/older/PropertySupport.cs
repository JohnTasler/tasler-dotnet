﻿using System;
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
			if (propertyExpression == null)
				throw new ArgumentNullException("propertyExpression");

			var memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
				throw new ArgumentException(Resources.PropertySupport_NotMemberAccessExpression_Exception, "propertyExpression");

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
				throw new ArgumentException(Resources.PropertySupport_ExpressionNotProperty_Exception, "propertyExpression");

			var getMethod = property.GetGetMethod(true);
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
			if (propertyExpression == null)
				throw new ArgumentNullException("propertyExpression");

			var memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
			{
				var unaryExpression = propertyExpression.Body as UnaryExpression;
				if (unaryExpression == null)
					throw new ArgumentException(Resources.PropertySupport_BodyNotUnaryExpression_Exception, "propertyExpression");

				memberExpression = unaryExpression.Operand as MemberExpression;
				if (memberExpression == null)
					throw new ArgumentException(Resources.PropertySupport_NotMemberAccessExpression_Exception, "propertyExpression");
			}

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
				throw new ArgumentException(Resources.PropertySupport_ExpressionNotProperty_Exception, "propertyExpression");

			var getMethod = property.GetGetMethod(true);
			if (getMethod.IsStatic)
				throw new ArgumentException(Resources.PropertySupport_StaticExpression_Exception, "propertyExpression");

			return memberExpression.Member.Name;
		}
	}
}
