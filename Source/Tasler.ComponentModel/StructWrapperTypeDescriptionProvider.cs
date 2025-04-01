using System.ComponentModel;
using System.Reflection;

namespace Tasler.ComponentModel;

public class StructWrapperTypeDescriptionProvider : TypeDescriptionProvider
{
	#region Static Fields
	private static Dictionary<Type, TypeDescriptionProvider> providerMap = new();
	#endregion

	#region Construction
	private StructWrapperTypeDescriptionProvider(Type type)
		: base(TypeDescriptor.GetProvider(type))
	{
	}
	#endregion

	#region Static Methods
	public static void AddInstanceProvider(object instance)
	{
		ValidateArgument.IsNotNull(instance, nameof(instance));

		Type type = instance.GetType();
		TypeDescriptionProvider? provider;
		if (!providerMap.TryGetValue(type, out provider))
		{
			provider = new StructWrapperTypeDescriptionProvider(type);
			providerMap.Add(type, provider);
		}

		TypeDescriptor.AddProvider(provider, instance);
	}
	#endregion

	public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object? instance)
	{
		ICustomTypeDescriptor? parent = base.GetTypeDescriptor(objectType, instance);
		return new StructWrapperTypeDescriptor(parent, instance?.GetType() ?? typeof(Type));
	}

	#region Nested Types
	private class StructWrapperTypeDescriptor : CustomTypeDescriptor
	{
		#region Instance Fields
		private Type _type;
		#endregion

		#region Construction
		public StructWrapperTypeDescriptor(ICustomTypeDescriptor? parent, Type type)
			: base(parent)
		{
			_type = type;
		}
		#endregion

		public override PropertyDescriptorCollection GetProperties()
		{
			// Get the reflected instance fields of the object
			BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
			FieldInfo[] fields = _type.GetFields(flags);
			PropertyDescriptor[] props = new PropertyDescriptor[fields.Length];
			for (int i = 0; i < fields.Length; ++i)
			{
				FieldWrapperPropertyDescriptor prop =
					new FieldWrapperPropertyDescriptor(_type, fields[i]);
				props[i] = prop;
			}

			return new PropertyDescriptorCollection(props);
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[]? attributes)
		{
			return this.GetProperties();
		}
	}

	private class FieldWrapperPropertyDescriptor : PropertyDescriptor
	{
		#region Instance Fields
		private bool _isExpandable;
		private Type _componentType;
		private FieldInfo _fieldInfo;
		#endregion

		#region Construction
		public FieldWrapperPropertyDescriptor(Type componentType, FieldInfo fieldInfo)
			: this(componentType, fieldInfo, [])
		{
		}

		public FieldWrapperPropertyDescriptor(Type componentType, FieldInfo fieldInfo, Attribute[] attributes)
			: base(fieldInfo.Name, attributes)
		{
			_componentType = componentType;
			_fieldInfo = fieldInfo;

			BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
			_isExpandable = this.PropertyType.GetFields(flags).Length > 0;

			if (_isExpandable)
			{
				var newAttributes = new List<Attribute>(this.AttributeArray ?? [])
				{
					new TypeConverterAttribute(typeof(ExpandableObjectConverter))
				};
				this.AttributeArray = newAttributes.ToArray();
			}
		}
		#endregion

		#region Overrides
		public override bool CanResetValue(object component)
		{
			var attribute = (DefaultValueAttribute?)this.Attributes[typeof(DefaultValueAttribute)];
			if (attribute is null)
			{
				return false;
			}
			return attribute.Value!.Equals(this.GetValue(component));
		}

		public override void ResetValue(object component)
		{
			var attribute = (DefaultValueAttribute?)this.Attributes[typeof(DefaultValueAttribute)];
			if (attribute is not null)
			{
				this.SetValue(component, attribute.Value!);
			}
		}

		public override bool ShouldSerializeValue(object component) => false;

		public override Type ComponentType => _componentType;

		public override bool IsReadOnly => true;

		public override Type PropertyType => _fieldInfo.FieldType;

		public override object? GetValue(object? component)
		{
			var value = _fieldInfo.GetValue(component);
			if (_isExpandable && value is not null)
			{
				StructWrapperTypeDescriptionProvider.AddInstanceProvider(value);
			}
			return value;
		}

		public override void SetValue(object? component, object? value)
			=> _fieldInfo.SetValue(component, value);

		public override AttributeCollection Attributes => base.Attributes;
		#endregion
	}
	#endregion
}
