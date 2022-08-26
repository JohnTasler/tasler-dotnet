using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// Provides a set of extension methods for implementing property setters in objects that implement
	/// the <see cref="IRaisePropertyChanged"/> interface.
	/// </summary>
	public static class RaisePropertyChangedExtensions
	{
		#region Extension Methods

		#region RaisePropertyChanged for single property expression
		/// <summary>
		/// Raises the object's PropertyChanged event for the property specified by <paramref name="propertyExpression"/>.
		/// </summary>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="propertyExpression">The expression identifying the property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, TProperty>(this TSource instance,
			Expression<Func<TProperty>> propertyExpression)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
			return instance.RaisePropertyChanged(propertyName);
		}
		#endregion RaisePropertyChanged for single property expression

		#region RaisePropertyChanged for multiple property expressions
		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8>(this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <param name="exp12">The expression identifying the twelfth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
				PropertySupport.ExtractPropertyName(exp12),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <param name="exp12">The expression identifying the twelfth property that has changed.</param>
		/// <param name="exp13">The expression identifying the thirteenth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
				PropertySupport.ExtractPropertyName(exp12),
				PropertySupport.ExtractPropertyName(exp13),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <param name="exp12">The expression identifying the twelfth property that has changed.</param>
		/// <param name="exp13">The expression identifying the thirteenth property that has changed.</param>
		/// <param name="exp14">The expression identifying the fourteenth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
				PropertySupport.ExtractPropertyName(exp12),
				PropertySupport.ExtractPropertyName(exp13),
				PropertySupport.ExtractPropertyName(exp14),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <param name="exp12">The expression identifying the twelfth property that has changed.</param>
		/// <param name="exp13">The expression identifying the thirteenth property that has changed.</param>
		/// <param name="exp14">The expression identifying the fourteenth property that has changed.</param>
		/// <param name="exp15">The expression identifying the fifteenth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14, Expression<Func<T15>> exp15)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
				PropertySupport.ExtractPropertyName(exp12),
				PropertySupport.ExtractPropertyName(exp13),
				PropertySupport.ExtractPropertyName(exp14),
				PropertySupport.ExtractPropertyName(exp15),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}

		/// <summary>
		/// Raises this object's PropertyChanged event for multiple propertyExpressions.
		/// </summary>
		/// <typeparam name="T1">The type of the first property passed to this method.</typeparam>
		/// <typeparam name="T2">The type of the second passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth property passed to this method.</typeparam>
		/// <typeparam name="T16">The type of the sixteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="exp1">The expression identifying the first property that has changed.</param>
		/// <param name="exp2">The expression identifying the second property that has changed.</param>
		/// <param name="exp3">The expression identifying the third property that has changed.</param>
		/// <param name="exp4">The expression identifying the fourth property that has changed.</param>
		/// <param name="exp5">The expression identifying the fifth property that has changed.</param>
		/// <param name="exp6">The expression identifying the sixth property that has changed.</param>
		/// <param name="exp7">The expression identifying the seventh property that has changed.</param>
		/// <param name="exp8">The expression identifying the eighth property that has changed.</param>
		/// <param name="exp9">The expression identifying the ninth property that has changed.</param>
		/// <param name="exp10">The expression identifying the tenth property that has changed.</param>
		/// <param name="exp11">The expression identifying the eleventh property that has changed.</param>
		/// <param name="exp12">The expression identifying the twelfth property that has changed.</param>
		/// <param name="exp13">The expression identifying the thirteenth property that has changed.</param>
		/// <param name="exp14">The expression identifying the fourteenth property that has changed.</param>
		/// <param name="exp15">The expression identifying the fifteenth property that has changed.</param>
		/// <param name="exp16">The expression identifying the sixteenth property that has changed.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool RaisePropertyChanged<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
				this TSource instance,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14, Expression<Func<T15>> exp15, Expression<Func<T16>> exp16)
			where TSource : IRaisePropertyChanged
		{
			ValidateInstance(instance);
			var propertyNames = new string[]
			{
				PropertySupport.ExtractPropertyName(exp1),
				PropertySupport.ExtractPropertyName(exp2),
				PropertySupport.ExtractPropertyName(exp3),
				PropertySupport.ExtractPropertyName(exp4),
				PropertySupport.ExtractPropertyName(exp5),
				PropertySupport.ExtractPropertyName(exp6),
				PropertySupport.ExtractPropertyName(exp7),
				PropertySupport.ExtractPropertyName(exp8),
				PropertySupport.ExtractPropertyName(exp9),
				PropertySupport.ExtractPropertyName(exp10),
				PropertySupport.ExtractPropertyName(exp11),
				PropertySupport.ExtractPropertyName(exp12),
				PropertySupport.ExtractPropertyName(exp13),
				PropertySupport.ExtractPropertyName(exp14),
				PropertySupport.ExtractPropertyName(exp15),
				PropertySupport.ExtractPropertyName(exp16),
			};

			return instance.RaisePropertyChanged(propertyNames);
		}
		#endregion RaisePropertyChanged for multiple property expressions


		#region SetProperty for single property expression

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value, but does
		/// <b>not</b> invoke the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, TProperty>(this TSource instance, ref TProperty field, TProperty newValue)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
				field = newValue;

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="propertyExpression">The expression identifying the property for which a change notifications should be sent
		/// when the value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, TProperty>(this TSource instance, ref TProperty field, TProperty newValue, Expression<Func<TProperty>> propertyExpression)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, propertyExpression);
			}

			return hasChanged;
		}

		#endregion SetProperty for single property expression

		#region SetProperty for multiple property expressions

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp12">The expression identifying the twelfth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11, exp12);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp12">The expression identifying the twelfth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp13">The expression identifying the thirteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11, exp12, exp13);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp12">The expression identifying the twelfth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp13">The expression identifying the thirteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp14">The expression identifying the fourteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11, exp12, exp13, exp14);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp12">The expression identifying the twelfth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp13">The expression identifying the thirteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp14">The expression identifying the fourteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp15">The expression identifying the fifteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14, Expression<Func<T15>> exp15)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11, exp12, exp13, exp14, exp15);
			}

			return hasChanged;
		}

		/// <summary>
		/// Compares a field value to the specified value and, if not equal, sets the field to the new value and invokes
		/// the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <typeparam name="T1">The type of the field being compared. This is inferred from the <paramref name="field"/>
		/// and <paramref name="newValue"/> parameters, and does not normally need to be specified explicitly.</typeparam>
		/// <typeparam name="T2">The type of the second property passed to this method.</typeparam>
		/// <typeparam name="T3">The type of the third property passed to this method.</typeparam>
		/// <typeparam name="T4">The type of the fourth property passed to this method.</typeparam>
		/// <typeparam name="T5">The type of the fifth property passed to this method.</typeparam>
		/// <typeparam name="T6">The type of the sixth property passed to this method.</typeparam>
		/// <typeparam name="T7">The type of the seventh property passed to this method.</typeparam>
		/// <typeparam name="T8">The type of the eighth property passed to this method.</typeparam>
		/// <typeparam name="T9">The type of the ninth property passed to this method.</typeparam>
		/// <typeparam name="T10">The type of the tenth property passed to this method.</typeparam>
		/// <typeparam name="T11">The type of the eleventh property passed to this method.</typeparam>
		/// <typeparam name="T12">The type of the twelfth property passed to this method.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth property passed to this method.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth property passed to this method.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth property passed to this method.</typeparam>
		/// <typeparam name="T16">The type of the sixteenth property passed to this method.</typeparam>
		/// <param name="instance">The object instance that implements the property. This object must implement both the
		/// <see cref="INotifyPropertyChanged"/> and <see cref="IRaisePropertyChanged"/> interfaces.</param>
		/// <param name="field">A reference to the member field that backs the property being set.</param>
		/// <param name="newValue">The new value the property is being set to.</param>
		/// <param name="exp1">The expression identifying the first property for which a change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp2">The expression identifying the second property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp3">The expression identifying the third property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp4">The expression identifying the fourth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp5">The expression identifying the fifth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp6">The expression identifying the sixth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp7">The expression identifying the seventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp8">The expression identifying the eighth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp9">The expression identifying the ninth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp10">The expression identifying the tenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp11">The expression identifying the eleventh property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp12">The expression identifying the twelfth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp13">The expression identifying the thirteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp14">The expression identifying the fourteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp15">The expression identifying the fifteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <param name="exp16">The expression identifying the sixteenth property for which change notifications should be sent when the <paramref name="field"/> value changes.</param>
		/// <returns>
		///   <b>true</b> if the <paramref name="field"/> value was changed to <paramref name="newValue"/>;
		/// otherwise <b>false</b>.
		/// </returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="instance"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException">If the specified <paramref name="instance"/> does not implement the
		/// <see cref="IRaisePropertyChanged"/> interface.</exception>
		public static bool SetProperty<TSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
				this TSource instance, ref T1 field, T1 newValue,
			Expression<Func<T1>> exp1, Expression<Func<T2>> exp2, Expression<Func<T3>> exp3, Expression<Func<T4>> exp4,
			Expression<Func<T5>> exp5, Expression<Func<T6>> exp6, Expression<Func<T7>> exp7, Expression<Func<T8>> exp8,
			Expression<Func<T9>> exp9, Expression<Func<T10>> exp10, Expression<Func<T11>> exp11, Expression<Func<T12>> exp12,
			Expression<Func<T13>> exp13, Expression<Func<T14>> exp14, Expression<Func<T15>> exp15, Expression<Func<T16>> exp16)
			where TSource : IRaisePropertyChanged
		{
			var hasChanged = !object.Equals(field, newValue);
			if (hasChanged)
			{
				field = newValue;
				RaisePropertyChanged(instance, exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9, exp10, exp11, exp12, exp13, exp14, exp15, exp16);
			}

			return hasChanged;
		}

		#endregion SetProperty for multiple property expressions

		#endregion Extension Methods

		#region Private Implementation
		private static void ValidateInstance(IRaisePropertyChanged instance)
		{
			if (instance == null)
				throw new ArgumentNullException("instance");
		}
		#endregion Private Implementation
	}
}
