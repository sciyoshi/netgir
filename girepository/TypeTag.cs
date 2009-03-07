using System;
using System.Collections.Generic;

namespace GIRepository
{
	public enum TypeTag
	{
		Void = 0,
		Boolean = 1,
		Int8 = 2,
		UInt8 = 3,
		Int16 = 4,
		UInt16 = 5,
		Int32 = 6,
		UInt32 = 7,
		Int64 = 8,
		UInt64 = 9,
		Int = 10,
		UInt = 11,
		Long = 12,
		ULong = 13,
		SSize = 14,
		Size = 15,
		Float = 16,
		Double = 17,
		TimeT = 18,
		GType = 19,
		Utf8 = 20,
		Filename = 21,
		Array = 22,
		Interface = 23,
		GList = 24,
		GSList = 25,
		GHash = 26,
		Error = 27
	}

	public class TypeTagMapping
	{
		private static Type[] Mapping = new Type[] {
			typeof(void),
			typeof(bool),
			typeof(sbyte),
			typeof(byte),
			typeof(short),
			typeof(ushort),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(IntPtr),
			typeof(UIntPtr),
			typeof(float),
			typeof(double),
			typeof(DateTime),
			typeof(Type),
			typeof(string),
			typeof(string),
			typeof(Array),
			typeof(GLib.IWrapper),
			typeof(GLib.List),
			typeof(GLib.SList),
			typeof(System.Collections.Hashtable),
			typeof(Exception)
		};

		private static System.Reflection.FieldInfo[] Fields = new System.Reflection.FieldInfo[] {
			null,
			typeof(Argument).GetField("VBoolean"),
			typeof(Argument).GetField("VInt8"),
			typeof(Argument).GetField("VUInt8"),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			typeof(Argument).GetField(""),
			
		};
			
		
		public static Type FromTag(TypeTag tag)
		{
			
			return Mapping[(int) tag];
		}
	}
}
