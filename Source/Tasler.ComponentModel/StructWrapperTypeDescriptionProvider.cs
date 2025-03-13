using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Tasler.ComponentModel 
{
	public class StructWrapperTypeDescriptionProvider : TypeDescriptionProvider 
	{
		#region Static Fields
		private static Dictionary<Type, TypeDescriptionProvider> providerMap =
			new Dictionary<Type, TypeDescriptionProvider>();
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
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}

			Type type = instance.GetType();
			TypeDescriptionProvider provider;
			if (!providerMap.TryGetValue(type, out provider))
			{
				provider = new StructWrapperTypeDescriptionProvider(type);
				providerMap.Add(type, provider);
			}

			TypeDescriptor.AddProvider(provider, instance);
		}
		#endregion

		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) 
		{
			ICustomTypeDescriptor parent = base.GetTypeDescriptor(objectType, instance);
			return new StructWrapperTypeDescriptor(parent, instance.GetType());
		}

		#region Nested Types
		private class StructWrapperTypeDescriptor : CustomTypeDescriptor 
		{
			#region Instance Fields
			private Type type;
			#endregion

			#region Construction
			public StructWrapperTypeDescriptor(ICustomTypeDescriptor parent, Type type)
				: base(parent)
			{
				this.type = type;
			}
			#endregion

			public override PropertyDescriptorCollection GetProperties()
			{
				// Get the reflected instance fields of the object
				BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
				FieldInfo[] fields = this.type.GetFields(flags);
				PropertyDescriptor[] props = new PropertyDescriptor[fields.Length];
				for (int i = 0; i < fields.Length; ++i)
				{
					FieldWrapperPropertyDescriptor prop =
						new FieldWrapperPropertyDescriptor(this.type, fields[i]);
					props[i] = prop;
				}

				return new PropertyDescriptorCollection(props);
			}

			public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
			{
				return this.GetProperties();
			}
		}

		private class FieldWrapperPropertyDescriptor : PropertyDescriptor 
		{
			#region Instance Fields
			private bool isExpandable;
			private Type componentType;
			private FieldInfo fieldInfo;
			#endregion

			#region Construction
			public FieldWrapperPropertyDescriptor(Type componentType, FieldInfo fieldInfo)
				: this(componentType, fieldInfo, new Attribute[0])
			{
			}

			public FieldWrapperPropertyDescriptor(Type componentType, FieldInfo fieldInfo, Attribute[] attributes)
				: base(fieldInfo.Name, attributes)
			{
				this.componentType = componentType;
				this.fieldInfo = fieldInfo;

				BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
				this.isExpandable = this.PropertyType.GetFields(flags).Length > 0;

				if (this.isExpandable)
				{
					List<Attribute> newAttributes = new List<Attribute>(this.AttributeArray);
					newAttributes.Add(new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
					this.AttributeArray = newAttributes.ToArray();
				}
			}
			#endregion

			#region Overrides
			public override bool CanResetValue(object component)
			{
				DefaultValueAttribute attribute = (DefaultValueAttribute)this.Attributes[typeof(DefaultValueAttribute)];
				if (attribute == null)
				{
					return false;
				}
				return attribute.Value.Equals(this.GetValue(component));
			}

			public override void ResetValue(object component)
			{
				DefaultValueAttribute attribute = (DefaultValueAttribute)this.Attributes[typeof(DefaultValueAttribute)];
				if (attribute != null)
				{
					this.SetValue(component, attribute.Value);
				}
			}

			public override bool ShouldSerializeValue(object component)
			{
				return false;
			}

			public override Type ComponentType
			{
				get
				{
					return this.componentType;
				}
			}

			public override bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			public override Type PropertyType
			{
				get
				{
					return this.fieldInfo.FieldType;
				}
			}

			public override object GetValue(object component)
			{
				object value = this.fieldInfo.GetValue(component);
				if (this.isExpandable)
				{
					StructWrapperTypeDescriptionProvider.AddInstanceProvider(value);
				}
				return value;
			}

			public override void SetValue(object component, object value)
			{
				this.fieldInfo.SetValue(component, value);
			}

			public override AttributeCollection Attributes
			{
				get
				{
					return base.Attributes;
				}
			}
			#endregion
		}
		#endregion
	}
}
