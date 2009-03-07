using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class TypeInfo : BaseInfo
	{
		public TypeInfo(IntPtr raw) : base(raw)
		{
			ErrorDomains = new ErrorDomainCollection(this);
		}

		public bool IsPointer {
			get { return gi_type_info_is_pointer(Handle); }
		}

		public TypeTag Tag {
			get { return gi_type_info_get_tag(Handle); }
		}

		public BaseInfo Interface {
			get { return (BaseInfo) GetOpaque(gi_type_info_get_interface(Handle), true); }
		}
		
		public TypeInfo GetParamType(int n)
		{
			return (TypeInfo) GetOpaque(gi_type_info_get_param_type(Handle, n), true);
		}

		public int ArrayLength {
			get { return gi_type_info_get_array_length(Handle); }
		}

		public int ArrayFixedSize {
			get { return gi_type_info_get_array_fixed_size(Handle); }
		}

		public bool IsZeroTerminated {
			get { return gi_type_info_is_zero_terminated(Handle); }
		}

		public class ErrorDomainCollection {
			readonly TypeInfo info;
			internal ErrorDomainCollection(TypeInfo info)
			{
				this.info = info;
			}
			public ErrorDomainInfo this[int n] {
				get { return gi_type_info_get_error_domain(info.Handle, n); }
			}
			public int Count {
				get { return gi_type_info_get_n_error_domains(info.Handle); }
			}
		}

		public ErrorDomainCollection ErrorDomains { get; private set; }
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool gi_type_info_is_pointer(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern TypeTag gi_type_info_get_tag(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr gi_type_info_get_param_type(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr gi_type_info_get_interface(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int gi_type_info_get_array_length(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern int gi_type_info_get_array_fixed_size(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool gi_type_info_is_zero_terminated(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int gi_type_info_get_n_error_domains(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern ErrorDomainInfo gi_type_info_get_error_domain(IntPtr raw, int n);
	}
}
