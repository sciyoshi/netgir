using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class CallableInfo : BaseInfo
	{
		public CallableInfo(IntPtr raw) : base(raw) { }

		public ObjectInfo ReturnType {
			get { return (ObjectInfo) GetOpaque(g_callable_info_get_return_type(Handle), false); }
		}
		
		public bool CallerOwns {
			get { return g_callable_info_get_caller_owns(Handle); }
		}

		public bool MayReturnNone {
			get { return g_callable_info_may_return_null(Handle); }
		}
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_callable_info_get_return_type(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_callable_info_get_caller_owns(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_callable_info_may_return_null(IntPtr raw);
	}
}
