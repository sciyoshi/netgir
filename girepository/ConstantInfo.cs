using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class ConstantInfo : BaseInfo
	{
		public ConstantInfo(IntPtr raw) : base(raw) { }

		public TypeInfo Type {
			get { return (TypeInfo) GetOpaque(gi_constant_info_get_type(Handle), true); }
		}
		
		public Argument GetValue(out int size)
		{
			Argument arg;
			size = gi_constant_info_get_value(Handle, out arg);
			return arg;
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr gi_constant_info_get_type(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern int gi_constant_info_get_value(IntPtr raw, out Argument value);
	}
}
