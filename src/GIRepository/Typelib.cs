using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class Typelib
	{
		internal IntPtr handle;

		internal Typelib(IntPtr handle)
		{
			this.handle = handle;
		}

		public static Typelib NewFromMemory(byte[] memory)
		{
			IntPtr array = GObject.Marshaller.Malloc((ulong) memory.Length);
			Marshal.Copy(array, memory, 0, memory.Length);
			Typelib lib = new Typelib(g_typelib_new_from_memory(array, (IntPtr) memory.Length));
			GObject.Marshaller.Free(array);
			return lib;
		}

		public unsafe static Typelib NewFromConstMemory(byte* memory, ulong length)
		{
			return new Typelib(g_typelib_new_from_const_memory(new IntPtr(memory), (IntPtr) length));
		}

		public override string ToString()
		{
			return String.Format("<Typelib: {0}>", Namespace);
		}
		
		public string Namespace {
			get { return GObject.Marshaller.Utf8PtrToString(g_typelib_get_namespace(handle)); }
		}

		public bool Symbol(string symbol_name, out IntPtr symbol)
		{
			IntPtr native_name = GObject.Marshaller.StringToPtrGStrdup(symbol_name);
			bool ret = g_typelib_symbol(handle, native_name, out symbol);
			GObject.Marshaller.Free(native_name);
			return ret;
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_typelib_new_from_memory(IntPtr raw, IntPtr len);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_typelib_new_from_const_memory(IntPtr raw, IntPtr len);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_typelib_get_namespace(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_typelib_symbol(IntPtr raw, IntPtr symbol_name, out IntPtr symbol);
	}
}
