using System.Runtime.CompilerServices;

namespace Tasler.Extensions;

public static class UnmanagedExtensions
{
	extension<T>(T @this) where T : unmanaged
	{
		/// <summary>
		/// Gets the binary size of an unmanaged type at compile time.
		/// </summary>
		/// <value>The binary size of the unmanaged type.</value>
		/// <remarks>
		///		<para>Prior to the focus on AOT compatibility, this value would be retrieved at runtime
		///		using the <see cref="Marshal.SizeOf{T}"/> method, which is not compatible with AOT. This
		///   extension property provides a way to get the size of the struct at compile time, which
		///   allows for the use of AOT compilation.</para>
		///   <para>Typically the static version of this extension property would be used. However
		///   static extension properties are currently only available on concrete types, not generic
		///   types. Having an instance extension property allows the size to be determined by using
		///   the <see langword="default"/> keyword in generic code as shown in the example below.</para>
		///   <code>
		///     int genericTypeByteCount = default(T).Size;
		///     int concreteTypeByteCount = uint.Size;
		///     int failingTypeByteCount = T.Size; // This will not compile, since T is a generic type.
		///                                        // It will generate Compiler Error CS0704 in C# 14.
		///   </code>
		/// </remarks>
		public int Size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unsafe
				{
					return sizeof(T);
				}
			}
		}

		/// <summary>
		/// Gets the binary size of an unmanaged type at compile time.
		/// </summary>
		/// <value>The binary size of the unmanaged type.</value>
		/// <remarks>
		///		<para>Prior to the focus on AOT compatibility, this value would be retrieved at runtime
		///		using the <see cref="Marshal.SizeOf{T}"/> method, which is not compatible with AOT. This
		///   extension property provides a way to get the size of the struct at compile time, which
		///   allows for the use of AOT compilation.
		///   </para>
		///   <para>Since static extension properties are currently only available on concrete types,
		///   not generic types, the <see cref="Size"/> instance extension property allows the size to
		///   be determined by using the <see langword="default"/> keyword in generic code as shown in
		///   the example below.
		///   </para>
		///   <code>
		///     int genericTypeByteCount = default(T).Size;
		///     int concreteTypeByteCount = uint.Size;
		///     int failingTypeByteCount = T.Size; // This will not compile, since T is a generic type.
		///                                        // It will generate Compiler Error CS0704 in C# 14.
		///   </code>
		///   <para>If the built-in <c>sizeof</c> operator is used on its own, the compiler will point
		///   out that the type must be unmanaged, and the <c>sizeof</c> operator must be done within
		///   an <see langword="unsafe"/> code context. This extension property abstracts away that
		///   requirement.
		///   </para>
		/// </remarks>
		public static int SizeOf
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unsafe
				{
					return sizeof(T);
				}
			}
		}
	}
}
