using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class BaseInfo : GLib.Opaque
	{
		private static readonly Dictionary<InfoType, Type> InfoTypeMappings = new Dictionary<InfoType, Type>()
		{
			{ InfoType.Function,    typeof(FunctionInfo) },
			{ InfoType.Callback,    typeof(CallbackInfo) },
			{ InfoType.Struct,      typeof(StructInfo) },
			{ InfoType.Boxed,       typeof(BoxedInfo) },
			{ InfoType.Enum,        typeof(EnumInfo) },
			{ InfoType.Flags,       typeof(FlagsInfo) },
			{ InfoType.Object,      typeof(ObjectInfo) },
			{ InfoType.Interface,   typeof(InterfaceInfo) },
			{ InfoType.Constant,    typeof(ConstantInfo) },
			{ InfoType.ErrorDomain, typeof(ErrorDomainInfo) },
			{ InfoType.Union,       typeof(UnionInfo) },
			{ InfoType.Value,       typeof(ValueInfo) },
			{ InfoType.Signal,      typeof(SignalInfo) },
			{ InfoType.VFunc,       typeof(VFuncInfo) },
			{ InfoType.Property,    typeof(PropertyInfo) },
			{ InfoType.Field,       typeof(FieldInfo) },
			{ InfoType.Arg,         typeof(ArgInfo) },
			{ InfoType.Type,        typeof(TypeInfo) },
			{ InfoType.Unresolved,  typeof(UnresolvedInfo) },
		};

		public BaseInfo(IntPtr raw) : base(raw) { }

		protected override void Ref(IntPtr raw)
		{
			g_base_info_ref(raw);
		}

		protected override void Unref(IntPtr raw)
		{
			g_base_info_unref(raw);
		}

		protected override void Free(IntPtr raw)
		{
			g_base_info_unref(raw);
		}

		protected override GLib.Opaque Copy(IntPtr raw)
		{
			g_base_info_ref(raw);
			return this;
		}

		public static BaseInfo GetOpaque(IntPtr raw, bool owned)
		{
			Type type;

			if (raw == IntPtr.Zero || !InfoTypeMappings.TryGetValue(g_base_info_get_type(raw), out type))
				return null;

			return (BaseInfo) GetOpaque(raw, type, owned);
		}

		public string Name {
			get { return GLib.Marshaller.Utf8PtrToString(g_base_info_get_name(Handle)); }
		}

		public Typelib Typelib {
			get { return new Typelib(g_base_info_get_typelib(Handle)); }
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_base_info_ref(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern void g_base_info_unref(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern InfoType g_base_info_get_type(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_base_info_get_name(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_base_info_get_typelib(IntPtr raw);
	}

	public class UnresolvedInfo : BaseInfo { public UnresolvedInfo(IntPtr raw) : base(raw) { } }
	public class CallableInfo : BaseInfo { public CallableInfo(IntPtr raw) : base(raw) { } }
	public class FunctionInfo : CallableInfo { public FunctionInfo(IntPtr raw) : base(raw) { } }
	public class CallbackInfo : CallableInfo { public CallbackInfo(IntPtr raw) : base(raw) { } }
	public class SignalInfo : CallableInfo { public SignalInfo(IntPtr raw) : base(raw) { } }

	public class PropertyInfo : BaseInfo { public PropertyInfo(IntPtr raw) : base(raw) { } }
	public class FieldInfo : BaseInfo { public FieldInfo(IntPtr raw) : base(raw) { } }
	public class ArgInfo : BaseInfo { public ArgInfo(IntPtr raw) : base(raw) { } }

	public class RegisteredTypeInfo : BaseInfo { public RegisteredTypeInfo(IntPtr raw) : base(raw) { } }
	public class StructInfo : RegisteredTypeInfo { public StructInfo(IntPtr raw) : base(raw) { } }
	public class EnumInfo : RegisteredTypeInfo { public EnumInfo(IntPtr raw) : base(raw) { } }
	public class FlagsInfo : RegisteredTypeInfo { public FlagsInfo(IntPtr raw) : base(raw) { } }
	public class BoxedInfo : RegisteredTypeInfo { public BoxedInfo(IntPtr raw) : base(raw) { } }
	public class ErrorDomainInfo : RegisteredTypeInfo { public ErrorDomainInfo(IntPtr raw) : base(raw) { } }
	public class InterfaceInfo : RegisteredTypeInfo { public InterfaceInfo(IntPtr raw) : base(raw) { } }
	public class UnionInfo : RegisteredTypeInfo { public UnionInfo(IntPtr raw) : base(raw) { } }
}
