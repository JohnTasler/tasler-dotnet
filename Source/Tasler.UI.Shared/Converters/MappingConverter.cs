using System.Collections;
using System.Diagnostics;
using CommunityToolkit.Diagnostics;

#if WINDOWS_UWP
using Windows.UI.Xaml.Markup;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
using ImageSource = Windows.UI.Xaml.Media.ImageSource;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using System.Windows.Markup;
using ConverterBase = Tasler.Windows.Converters.BaseValueConverter;
using ImageSource = System.Windows.Media.ImageSource;
namespace Tasler.Windows.Converters;
#endif

/// <summary>
/// A value converter that maps one value to another, possibly of a different type.
/// </summary>
/// <remarks>
/// <para>This is intended to be used from XAML, with the element content being used to populate the collection
/// exposed by the <see cref="Mappings"/> property.</para>
/// <para>In WPF applications, you can often just declare your mappings using the <see cref="Mapping"/> type,
/// which maps any <see cref="System.Object"/> to a value of <see cref="System.Object"/>. However, to assist
/// the XAML parser with type conversion (as is usually needed in Silverlight), you may want to declare a
/// type-specific mapping by deriving a class from the <see cref="Mapping{TKey, TValue}"/> generic type. The derived mapping
/// need not have any members since its declaration simply provides the key/value types.</para>
/// </remarks>
/// <example>
/// <para>The following C# code defines an enumeration type and a mapping of that enumeration type to an
/// <see cref="ImageSource"/>:</para>
/// <code>
///     public enum Severity
///     {
///         Info,
///         Warning,
///         Error,
///     }
///
///     <![CDATA[public class SeverityToImageMapping : Mapping<Severity, ImageSource>]]>
///     {
///     }
/// </code>
/// <para>The following XAML fragment shows the use of <see cref="MappingConverter"/> to map the enumeration
/// values to images:</para>
/// <code>
/// <![CDATA[
///     <UserControl.Resources>
///         <z:MappingConverter x:Key="severityToImageMappingConverter">
///             <app:SeverityToImageMapping Key="Info" Value="images/Info.png" />
///             <app:SeverityToImageMapping Key="Warning" Value="images/Warning.png" />
///             <app:SeverityToImageMapping Key="Error" Value="images/Error.png" />
///         </z:MappingConverter>
///     </UserControl.Resources>
/// ]]>
/// </code>
/// <para>Note that for this case, in WPF, the derived class is unnecessary, since WPF's XAML parser supports the
/// <code>x:Static</code> markup extension:</para>
/// <code>
/// <![CDATA[
///     <UserControl.Resources>
///         <z:MappingConverter x:Key="severityToImageMappingConverter">
///             <z:Mapping Key="{x:Static app:Severity.Info}" Value="images/Info.png" />
///             <z:Mapping Key="{x:Static app:Severity.Warning}" Value="images/Warning.png" />
///             <z:Mapping Key="{x:Static app:Severity.Error}" Value="images/Error.png" />
///         </z:MappingConverter>
///     </UserControl.Resources>
/// </code>
/// </example>
/// <seealso cref="IMapping"/>
/// <seealso cref="Mapping"/>
/// <seealso cref="Mapping{TKey, TValue}"/>
/// <seealso cref="MappingCollection"/>
#if WINDOWS_UWP
[ContentProperty(Name = nameof(Mappings))]
#elif WINDOWS_WPF
[ContentProperty(nameof(Mappings))]
#endif
public partial class MappingConverter : ConverterBase
{
	#region Properties
	/// <summary>
	/// Gets the collection of mappings.
	/// </summary>
	/// <value>An instance of type <see cref="MappingCollection"/>.</value>
	/// <seealso cref="IMapping"/>
	/// <seealso cref="Mapping"/>
	/// <seealso cref="Mapping{TKey, TValue}"/>
	/// <seealso cref="MappingCollection"/>
	public MappingCollection Mappings => _mappings;
	private readonly MappingCollection _mappings = [];

	public object? DefaultValue
	{
		get => _defaultValue;
		set
		{
			_defaultValue = value;
			_hasDefaultValueBeenSet = true;
		}
	}
	private object? _defaultValue;
	private bool _hasDefaultValueBeenSet;
	#endregion Properties

	#region IValueConverter Members

	/// <summary>
	/// Modifies the source data before passing it to the target for display in the UI.
	/// </summary>
	/// <param name="value">The source data being passed to the target.</param>
	/// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the target dependency property.</param>
	/// <param name="parameter">An optional parameter to be used in the converter logic.</param>
	/// <param name="culture">The culture of the conversion.</param>
	/// <returns>
	/// The value to be passed to the target dependency property.
	/// </returns>
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		object? mappedValue;
		if (!_mappings.TryFind(value!, out mappedValue))
			mappedValue = _hasDefaultValueBeenSet ? DefaultValue : value;
		Debug.WriteLine(string.Format("MappingConverter.Convert: {0}={1}\n", value, mappedValue));
		return mappedValue;
	}

	/// <summary>
	/// Modifies the target data before passing it to the source object.  This method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay"/> bindings.
	/// </summary>
	/// <param name="value">The target data being passed to the source.</param>
	/// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the source object.</param>
	/// <param name="parameter">An optional parameter to be used in the converter logic.</param>
	/// <param name="culture">The culture of the conversion.</param>
	/// <returns>
	/// The value to be passed to the source object.
	/// </returns>
	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}

	#endregion IValueConverter Members
}

/// <summary>
/// Defines a simple key/value object pair.
/// </summary>
/// <seealso cref="Mapping"/>
/// <seealso cref="Mapping{TKey, TValue}"/>
/// <seealso cref="MappingCollection"/>
/// <seealso cref="MappingConverter"/>
public interface IMapping
{
	/// <summary>
	/// Gets the key in the key/value pair.
	/// </summary>
	object Key { get; }

	/// <summary>
	/// Gets the value in the key/value pair.
	/// </summary>
	object? Value { get; }
}

/// <summary>
/// Provides a generically typed implementation of the <see cref="IMapping"/> interface,
/// which defines a simple key/value object pair.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="IMapping"/>
/// <seealso cref="Mapping"/>
/// <seealso cref="MappingCollection"/>
/// <seealso cref="MappingConverter"/>
#if WINDOWS_UWP
[ContentProperty(Name = nameof(Value))]
#elif WINDOWS_WPF
[ContentProperty(nameof(Value))]
#endif
public class Mapping<TKey, TValue> : IMapping
{
	#region Properties
	/// <summary>
	/// Gets or sets the key in the key/value pair.
	/// </summary>
	/// <value></value>
	public required TKey? Key { get; init; }

	/// <summary>
	/// Gets or sets the value in the key/value pair.
	/// </summary>
	/// <value></value>
	public TValue? Value { get; set; }
	#endregion Properties

	#region IMapping interface
	object IMapping.Key => this.Key!;
	object? IMapping.Value => this.Value;
	#endregion IMapping interface
}

/// <summary>
/// Implements the <see cref="Mapping{TKey, TValue}"/> generic type for an untyped key/value pair.
/// </summary>
/// <seealso cref="IMapping"/>
/// <seealso cref="Mapping{TKey, TValue}"/>
/// <seealso cref="MappingCollection"/>
/// <seealso cref="MappingConverter"/>
public class Mapping : Mapping<object, object?>
{
}

/// <summary>
/// An ordered collection of <see cref="IMapping"/> objects, with <see cref="IMapping.Key"/> values
/// cached for quick lookup.
/// </summary>
/// <seealso cref="IMapping"/>
/// <seealso cref="Mapping"/>
/// <seealso cref="Mapping{TKey, TValue}"/>
/// <seealso cref="MappingConverter"/>
public partial class MappingCollection : IList<IMapping>, IList
{
	#region Instance Fields
	private List<IMapping> _list = [];
	private Dictionary<object, object?> _dictionary = [];
	#endregion Instance Fields

	#region Methods
	/// <summary>
	/// Finds the value associated with the specified <paramref name="key"/>.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns>
	/// The value associated with the specified <paramref name="key"/>, if any; otherwise <c>null</c>.
	/// </returns>
	/// <remarks>
	/// This is used internally by the <see cref="MappingConverter"/> class. Since a key may be associated with a
	/// <c>null</c> value, a <c>null</c> return value gives no indication of whether the key exists.
	/// </remarks>
	public object? Find(object key)
	{
		_dictionary.TryGetValue(key, out object? result);
		return result;
	}

	public bool TryFind(object key, out object? value)
	{
		return _dictionary.TryGetValue(key, out value);
	}
	#endregion Methods

	#region IList<IMapping> Members

	int IList<IMapping>.IndexOf(IMapping item) => _list.IndexOf(item);

	void IList<IMapping>.Insert(int index, IMapping item)
	{
		_list.Insert(index, item);
		_dictionary.Add(item.Key, item.Value);
	}

	void IList<IMapping>.RemoveAt(int index)
	{
		_dictionary.Remove(_list[index].Key);
		_list.RemoveAt(index);
	}

	IMapping IList<IMapping>.this[int index]
	{
		get => _list[index];
		set
		{
			if (index < _list.Count)
				_dictionary.Remove(_list[index].Key);

			_dictionary[value.Key] = value.Value;
			_list[index] = value;
		}
	}

	#endregion IList<IMapping> Members

	#region ICollection<IMapping> Members

	int ICollection<IMapping>.Count => this._list.Count;

	bool ICollection<IMapping>.IsReadOnly => ((IList)_list).IsReadOnly;

	public void Add(IMapping item)
	{
		this._list.Add(item);
		this._dictionary.Add(item.Key, item.Value);
	}

	void ICollection<IMapping>.Clear()
	{
		this._dictionary.Clear();
		this._list.Clear();
	}

	bool ICollection<IMapping>.Contains(IMapping item)
		=> this._dictionary.ContainsKey(item);

	void ICollection<IMapping>.CopyTo(IMapping[] array, int arrayIndex)
		=> this._list.CopyTo(array, arrayIndex);

	bool ICollection<IMapping>.Remove(IMapping item)
	{
		this._dictionary.Remove(item.Key);
		return this._list.Remove(item);
	}

	#endregion ICollection<IMapping> Members

	#region IEnumerable<IMapping> Members

	IEnumerator<IMapping> IEnumerable<IMapping>.GetEnumerator() => this._list.GetEnumerator();

	#endregion IEnumerable<IMapping> Members

	#region IList, ICollection, IEnumerable all pass-through to generic methods

	/// IList Members
	int IList.Add(object? value)
	{
		((IList<IMapping>)this).Add((IMapping)value!);
		return this._list.Count - 1;
	}
	void IList.Clear() => ((IList<IMapping>)this).Clear();
	bool IList.Contains(object? value) => ((IList<IMapping>)this).Contains((IMapping)value!);
	int IList.IndexOf(object? value) => ((IList<IMapping>)this).IndexOf((IMapping)value!);
	void IList.Insert(int index, object? value) => ((IList<IMapping>)this).Insert(index, (IMapping)value!);
	bool IList.IsFixedSize => false;
	bool IList.IsReadOnly => false;
	void IList.Remove(object? value) => ((IList<IMapping>)this).Remove((IMapping)value!);
	void IList.RemoveAt(int index) => ((IList<IMapping>)this).RemoveAt(index);
	object? IList.this[int index]
	{
		get => ((IList<IMapping>)this)[index];
		set
		{
			Guard.IsNotNull(value);
			Guard.IsAssignableToType<IMapping>(value);

			((IList<IMapping>)this)[index] = (value as IMapping)!;
		}
	}

	// ICollection Members
	void ICollection.CopyTo(Array array, int index) => ((IList<IMapping>)this).CopyTo((IMapping[])array, index);
	int ICollection.Count => ((IList<IMapping>)this).Count;
	bool ICollection.IsSynchronized => false;
	object ICollection.SyncRoot => _list;

	// IEnumerable Members
	IEnumerator IEnumerable.GetEnumerator() => this._list.GetEnumerator();

	#endregion IList, ICollection, IEnumerable all pass-through to generic methods
}
