using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class ValueInfo : BaseInfo
	{
		public ValueInfo(IntPtr raw) : base(raw) { }

		public long Value {
			get { return gi_value_info_get_value(Handle); }
		}
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern long gi_value_info_get_value(IntPtr raw);
	}
}
