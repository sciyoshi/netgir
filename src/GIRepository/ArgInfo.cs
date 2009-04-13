using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class ArgInfo : BaseInfo
	{
		public ArgInfo(IntPtr raw) : base(raw) { }

		public Direction Direction {
			get { return g_arg_info_get_direction(Handle); }
		}
		
		public bool IsDipper {
			get { return g_arg_info_is_dipper(Handle); }
		}

		public bool IsReturnValue {
			get { return g_arg_info_is_return_value(Handle); }
		}

		public bool IsOptional {
			get { return g_arg_info_is_optional(Handle); }
		}

		public bool MayBeNull {
			get { return g_arg_info_may_be_null(Handle); }
		}

		public Transfer OwnershipTransfer {
			get { return g_arg_info_get_ownership_transfer(Handle); }
		}

		public ScopeType Scope {
			get { return g_arg_info_get_scope(Handle); }
		}

		public TypeInfo Type {
			get { return (TypeInfo) GetOpaque(g_arg_info_get_type(Handle), false); }
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern Direction g_arg_info_get_direction(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_arg_info_is_dipper(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_arg_info_is_return_value(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_arg_info_is_optional(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_arg_info_may_be_null(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern Transfer g_arg_info_get_ownership_transfer(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern ScopeType g_arg_info_get_scope(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_arg_info_get_closure(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_arg_info_get_destroy(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_arg_info_get_type(IntPtr raw);
	}
}
