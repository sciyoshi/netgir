using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class VFuncInfo : CallableInfo
	{
		public VFuncInfo(IntPtr raw) : base(raw) { }

		public VFuncInfoFlags Flags {
			get { return gi_vfunc_info_get_flags(Handle); }
		}

		public int Offset {
			get { return gi_vfunc_info_get_offset(Handle); }
		}

		public SignalInfo Signal {
			get { return (SignalInfo) GetOpaque(gi_vfunc_info_get_signal(Handle), true); }
		}
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern VFuncInfoFlags gi_vfunc_info_get_flags(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int gi_vfunc_info_get_offset(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr gi_vfunc_info_get_signal(IntPtr raw);
	}
}
