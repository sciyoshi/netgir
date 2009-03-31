using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class CallbackInfo : CallableInfo
	{
		public CallbackInfo(IntPtr raw) : base(raw) { }
	}
}
