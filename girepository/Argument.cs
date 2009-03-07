using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Argument
	{
		[FieldOffset(0)]
		public bool VBoolean;
		[FieldOffset(0)]
		public byte VInt8;
		[FieldOffset(0)]
		public sbyte VUInt8;
		[FieldOffset(0)]
		public short VInt16;
		[FieldOffset(0)]
		public ushort VUInt16;
		[FieldOffset(0)]
		public int VInt32;
		[FieldOffset(0)]
		public uint VUInt32;
		[FieldOffset(0)]
		public long VInt64;
		[FieldOffset(0)]
		public ulong VUInt64;
		[FieldOffset(0)]
		public float VFloat;
		[FieldOffset(0)]
		public double VDouble;
		[FieldOffset(0)]
		public IntPtr VInt;
		[FieldOffset(0)]
		public UIntPtr VUInt;
		[FieldOffset(0)]
		public long VLong;
		[FieldOffset(0)]
		public ulong VULong;
		[FieldOffset(0)]
		public IntPtr VSSize;
		[FieldOffset(0)]
		public UIntPtr VSize;
		[FieldOffset(0)]
		public IntPtr VPointer;
	}
}
