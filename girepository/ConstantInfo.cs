using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class ConstantInfo : BaseInfo
	{
		public ConstantInfo(IntPtr raw) : base(raw) { }

		public TypeInfo Type {
			get { return (TypeInfo) GetOpaque(g_constant_info_get_type(Handle), true); }
		}

		public object GetValue()
		{
			int size;
			Argument arg;
			size = g_constant_info_get_value(Handle, out arg);
			return Type.GetValue(arg, size);
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_constant_info_get_type(IntPtr raw);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_constant_info_get_value(IntPtr raw, out Argument value);
	}
}
