using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class TypeInfo : BaseInfo
	{
		public TypeInfo(IntPtr raw) : base(raw)
		{
			ErrorDomains = new CollectionProperty<ErrorDomainInfo>(this, g_type_info_get_n_error_domains, g_type_info_get_error_domain);
		}

		public bool IsPointer {
			get { return g_type_info_is_pointer(Handle); }
		}

		public TypeTag Tag {
			get { return g_type_info_get_tag(Handle); }
		}

		public BaseInfo Interface {
			get { return (BaseInfo) GetOpaque(g_type_info_get_interface(Handle), true); }
		}
		
		public TypeInfo GetParamType(int n)
		{
			return (TypeInfo) GetOpaque(g_type_info_get_param_type(Handle, n), true);
		}

		public int ArrayLength {
			get { return g_type_info_get_array_length(Handle); }
		}

		public int ArrayFixedSize {
			get { return g_type_info_get_array_fixed_size(Handle); }
		}

		public bool IsZeroTerminated {
			get { return g_type_info_is_zero_terminated(Handle); }
		}

		public CollectionProperty<ErrorDomainInfo> ErrorDomains { get; private set; }

		public object GetValue(Argument arg, int size)
		{
			switch (Tag)
			{
			case TypeTag.Boolean:
			case TypeTag.Int8:
			case TypeTag.UInt8:
			case TypeTag.Int16:
			case TypeTag.UInt16:
			case TypeTag.Int32:
			case TypeTag.UInt32:
			case TypeTag.Int64:
			case TypeTag.UInt64:
			case TypeTag.Int:
			case TypeTag.UInt:
			case TypeTag.Long:
			case TypeTag.ULong:
			case TypeTag.SSize:
			case TypeTag.Size:
			case TypeTag.Float:
			case TypeTag.Double:
				return typeof(Argument).GetField(Tag.ToString()).GetValue(arg);
			case TypeTag.Utf8:
				return GObject.Marshaller.Utf8PtrToString((IntPtr) arg.Pointer);
			default:
				return null;
			}
		}
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_type_info_is_pointer(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern TypeTag g_type_info_get_tag(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_type_info_get_param_type(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_type_info_get_interface(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_type_info_get_array_length(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_type_info_get_array_fixed_size(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_type_info_is_zero_terminated(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_type_info_get_n_error_domains(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_type_info_get_error_domain(IntPtr raw, int n);
	}
}
