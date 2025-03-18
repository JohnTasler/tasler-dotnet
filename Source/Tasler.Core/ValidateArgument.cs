using System;
using System.Reflection;

namespace Tasler;

public static class ValidateArgument
{
	/// <summary>
	/// Throws an <see cref="ArgumentNullException"/> if the specified argument is <c>null</c>.
	/// </summary>
	/// <param name="argument">The argument.</param>
	/// <param name="argumentName">The argument name.</param>
	/// <param name="message">A message that describes the error. Optional.</param>
	/// <exception cref="ArgumentNullException">Either <paramref name="argumentName"/> or <paramref name="argument"/> is <c>null</c>.</exception>
	/// <returns><paramref name="argument"/></returns>
	public static T IsNotNull<T>(T? argument, string argumentName, string? message = null)
		where T : class
	{
		if (argument is null)
		{
			throw new ArgumentNullException(argumentName, message);
		}

		return argument;
	}

	public static T IsNotNull<T>(T? argument, Func<string> argumentNameCreator, Func<string>? messageCreator = null)
			where T : class
	{
		if (argument is null)
		{
			throw new ArgumentNullException(argumentNameCreator(), messageCreator != null ? messageCreator() : null);
		}

		return argument;
	}

	/// <summary>
	/// Throws <see cref="ArgumentNullException"/> if the specified argument is null, or <see cref="ArgumentException"/>
	/// if the specified argument empty, or contains only whitespace.
	/// </summary>
	/// <param name="parameter">The argument.</param>
	/// <param name="parameterName">The argument name.</param>
	/// <param name="message">A message that describes the error. Optional.</param>
	/// <exception cref="ArgumentNullException">Either <paramref name="parameterName"/> or <paramref name="parameter"/> is <c>null</c>.</exception>
	/// <exception cref="ArgumentException">The <paramref name="parameter"/> is empty or contains only whitespace.</exception>
	/// <returns><paramref name="parameter"/></returns>
	public static string? IsNotNullOrWhiteSpace(string? parameter, string parameterName, string? message = null)
	{
		ValidateArgument.IsNotNull(parameter, parameterName, message);

		if (string.IsNullOrWhiteSpace(parameter))
		{
			var exceptionMessage = message ?? "Argument cannot be null, empty, or contain only whitespace.";
			throw new ArgumentException(parameterName, message);
		}

		return parameter;
	}

	public static TInterface ImplementsInterface<TInterface>(object parameter, string parameterName)
	{
		ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
		ValidateArgument.IsNotNull(parameter, parameterName);

		if (!typeof(TInterface).GetTypeInfo().IsInterface)
		{
			var message = string.Format("Generic argument type is not an interface: {0}", typeof(TInterface));
			throw new ArgumentException(message, nameof(TInterface));
		}

		if (!(parameter is TInterface))
		{
			var message = string.Format("Type of argument does not implement interface type {0}: {1}", typeof(TInterface), parameter.GetType());
			throw new ArgumentException(message, parameterName);
		}

		return (TInterface)parameter;
	}

	private static void IsOrIsDerivedFromImpl<TBase>(Type type, string parameterName, Func<string> messageCreator)
	{
		ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
		ValidateArgument.IsNotNull(type, parameterName);
		ValidateArgument.IsNotNull(messageCreator, nameof(messageCreator));

		if (!typeof(TBase).IsAssignableFrom(type))
		{
			var message = messageCreator();
			throw new ArgumentException(message, parameterName);
		}
	}

	public static void IsOrIsDerivedFrom<TBase>(Type type, string parameterName)
	{
		ValidateArgument.IsOrIsDerivedFromImpl<TBase>(type, parameterName,
				() => $"Specified type must be, or be derived from type {typeof(TBase)}: {type}");
	}

	public static void IsOrIsDerivedFrom<T, TBase>(string parameterName)
	{
		ValidateArgument.IsOrIsDerivedFrom<TBase>(typeof(T), parameterName);
	}

	public static TBase IsOrIsDerivedFrom<TBase>(object? parameter, string parameterName)
	{
		ValidateArgument.IsNotNull(parameter, parameterName);
		ValidateArgument.IsOrIsDerivedFromImpl<TBase>(parameter!.GetType(), parameterName,
				() => $"Type of argument is not derived from type ${typeof(TBase)}: {parameter.GetType()}");

		return (TBase)parameter;
	}

	private static void IsDerivedFromImpl<TBase>(Type type, string parameterName, Func<string> messageCreator)
			where TBase : class
	{
		ValidateArgument.IsNotNull(parameterName, nameof(parameterName));
		ValidateArgument.IsNotNull(type, parameterName);
		ValidateArgument.IsNotNull(messageCreator, messageCreator);

		if (typeof(TBase) == type || !typeof(TBase).IsAssignableFrom(type))
		{
			var message = messageCreator();
			throw new ArgumentException(message, parameterName);
		}
	}

	public static void IsDerivedFrom<TBase>(Type type, string parameterName)
			where TBase : class
	{
		ValidateArgument.IsDerivedFromImpl<TBase>(type, parameterName,
				() => $"Specified type must be derived from type {typeof(TBase)}: {type}");
	}

	public static void IsDerivedFrom<T, TBase>(string parameterName)
			where TBase : class
	{
		ValidateArgument.IsDerivedFrom<TBase>(typeof(T), parameterName);
	}

	public static TBase IsDerivedFrom<TBase>(object parameter, string parameterName)
			where TBase : class
	{
		ValidateArgument.IsNotNull(parameter, nameof(parameterName));
		ValidateArgument.IsDerivedFromImpl<TBase>(parameter.GetType(), parameterName,
				() => $"Type of argument is not derived from type ${typeof(TBase)}: {parameter.GetType()}");

		return (TBase)parameter;
	}

	public static T IsInRange<T>(T argument, T minValue, string argumentName, string? message = null)
			where T : struct, IComparable
	{
		if (argument.CompareTo(minValue) < 0)
		{
			throw new ArgumentOutOfRangeException(argumentName, message);
		}

		return argument;
	}

	public static T IsInRange<T>(T argument, T minValue, T maxValue, string argumentName, string? message = null)
			where T : struct, IComparable
	{
		if (argument.CompareTo(minValue) < 0 || argument.CompareTo(maxValue) > 0)
		{
			throw new ArgumentOutOfRangeException(argumentName, message);
		}

		return argument;
	}

	public static T IsInHalfOpenRange<T>(T argument, T minValue, T endValue, string argumentName, string? message = null)
			where T : struct, IComparable
	{
		if (argument.CompareTo(minValue) < 0 || endValue.CompareTo(argument) <= 0)
		{
			throw new ArgumentOutOfRangeException(argumentName, message);
		}

		return argument;
	}
}
