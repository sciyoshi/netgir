using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Argument
	{
		[FieldOffset(0)]
		public bool Boolean;
		[FieldOffset(0)]
		public byte Int8;
		[FieldOffset(0)]
		public sbyte UInt8;
		[FieldOffset(0)]
		public short Int16;
		[FieldOffset(0)]
		public ushort UInt16;
		[FieldOffset(0)]
		public int Int32;
		[FieldOffset(0)]
		public uint UInt32;
		[FieldOffset(0)]
		public long Int64;
		[FieldOffset(0)]
		public ulong UInt64;
		[FieldOffset(0)]
		public float Float;
		[FieldOffset(0)]
		public double Double;
		[FieldOffset(0)]
		public int Int;
		[FieldOffset(0)]
		public uint UInt;
		[FieldOffset(0)]
		public long Long;
		[FieldOffset(0)]
		public ulong ULong;
		[FieldOffset(0)]
		public int SSize;
		[FieldOffset(0)]
		public uint Size;
		[FieldOffset(0)]
		public IntPtr Pointer;
	}
}
