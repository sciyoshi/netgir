using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class Repository : GLib.Object
	{
		public Repository(IntPtr raw) : base(raw) {}

		public Repository() : base(g_irepository_get_default()) {}

		public static Repository GetDefault()
		{
			return new Repository();
		}

		public static void PrependSearchPath(string directory)
		{
			IntPtr native_directory = GLib.Marshaller.StringToPtrGStrdup(directory);
			g_irepository_prepend_search_path(native_directory);
			GLib.Marshaller.Free(native_directory);
		}

		public static Array GetSearchPath()
		{
			IntPtr path = g_irepository_get_search_path();
			return GLib.Marshaller.ListPtrToArray(path, typeof(GLib.SList), false, false, typeof(GLib.ListBase.FilenameString));
		}

		public static void Dump(string arg)
		{
			IntPtr error;
			IntPtr native_arg = GLib.Marshaller.StringToPtrGStrdup(arg);
			bool ret = g_irepository_dump(native_arg, out error);
			GLib.Marshaller.Free(native_arg);
			if (!ret)
				throw new GLib.GException(error);
		}

		public string LoadTypelib(Typelib typelib, RepositoryLoadFlags flags)
		{
			IntPtr error;
			IntPtr ret = g_irepository_load_typelib(Handle, typelib.handle, flags, out error);
			if (error != IntPtr.Zero)
				throw new GLib.GException (error);
			return GLib.Marshaller.Utf8PtrToString(ret);
		}

		public bool IsRegistered(string namespace_)
		{
			return IsRegistered(namespace_, null);
		}

		public bool IsRegistered(string namespace_, string version)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr native_version = GLib.Marshaller.StringToPtrGStrdup(version);
			bool ret = g_irepository_is_registered(Handle, native_namespace, native_version);
			GLib.Marshaller.Free(native_namespace);
			GLib.Marshaller.Free(native_version);
			return ret;
		}

		public BaseInfo FindByName(string namespace_, string name)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr native_name = GLib.Marshaller.StringToPtrGStrdup(name);
			IntPtr ret = g_irepository_find_by_name(Handle, native_namespace, native_name);
			GLib.Marshaller.Free(native_namespace);
			GLib.Marshaller.Free(native_name);
			return BaseInfo.GetOpaque(ret, true);
		}

		public Typelib Require(string namespace_)
		{
			return Require(namespace_, null, RepositoryLoadFlags.None);
		}

		public Typelib Require(string namespace_, RepositoryLoadFlags flags)
		{
			return Require(namespace_, null, flags);
		}

		public Typelib Require(string namespace_, string version, RepositoryLoadFlags flags)
		{
			IntPtr error;
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr native_version = GLib.Marshaller.StringToPtrGStrdup(version);
			IntPtr ret = g_irepository_require(Handle, native_namespace, native_version, flags, out error);
			GLib.Marshaller.Free(native_namespace);
			GLib.Marshaller.Free(native_version);
			if (error != IntPtr.Zero)
				throw new GLib.GException(error);
			return new Typelib(ret);
		}

		public string[] GetDependencies(string namespace_)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			string[] ret = GLib.Marshaller.PtrToStringArrayGFree(g_irepository_get_dependencies(Handle, native_namespace));
			GLib.Marshaller.Free(native_namespace);
			return ret;
		}

		public string[] GetLoadedNamespaces()
		{
			return GLib.Marshaller.PtrToStringArrayGFree(g_irepository_get_loaded_namespaces(Handle));
		}

		public BaseInfo FindByGType(GLib.GType gtype)
		{
			return BaseInfo.GetOpaque(g_irepository_find_by_gtype(Handle, gtype), true);
		}

		public int GetNInfos(string namespace_)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			int ret = g_irepository_get_n_infos(Handle, native_namespace);
			GLib.Marshaller.Free(native_namespace);
			return ret;
		}

		public BaseInfo GetInfo(string namespace_, int index)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr ret = g_irepository_get_info(Handle, native_namespace, index);
			GLib.Marshaller.Free(native_namespace);
			return BaseInfo.GetOpaque(ret, true);
		}

		public String GetTypelibPath(string namespace_)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr ret = g_irepository_get_typelib_path(Handle, native_namespace);
			GLib.Marshaller.Free(native_namespace);
			return GLib.Marshaller.Utf8PtrToString(ret);
		}

		public String GetSharedLibrary(string namespace_)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr ret = g_irepository_get_shared_library(Handle, native_namespace);
			GLib.Marshaller.Free(native_namespace);
			return GLib.Marshaller.Utf8PtrToString(ret);
		}

		public String GetVersion(string namespace_)
		{
			IntPtr native_namespace = GLib.Marshaller.StringToPtrGStrdup(namespace_);
			IntPtr ret = g_irepository_get_version(Handle, native_namespace);
			GLib.Marshaller.Free(native_namespace);
			return GLib.Marshaller.Utf8PtrToString(ret);
		}

		public static new GLib.GType GType {
			get {
				return new GLib.GType(g_irepository_get_type());
			}
		}

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_type();

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_default();

		[DllImport("libgirepository-1.0-0.dll")]
		static extern void g_irepository_prepend_search_path(IntPtr directory);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_search_path();

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_irepository_dump(IntPtr arg, out IntPtr error);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_load_typelib(IntPtr raw, IntPtr typelib, RepositoryLoadFlags flags, out IntPtr error);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_irepository_is_registered(IntPtr raw, IntPtr namespace_, IntPtr version);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_find_by_name(IntPtr raw, IntPtr namespace_, IntPtr name);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_require(IntPtr raw, IntPtr namespace_, IntPtr version, RepositoryLoadFlags flags, out IntPtr error);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_dependencies(IntPtr raw, IntPtr namespace_);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_loaded_namespaces(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_find_by_gtype(IntPtr raw, GLib.GType gtype);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_irepository_get_n_infos(IntPtr raw, IntPtr namespace_);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_info(IntPtr raw, IntPtr namespace_, int index);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_typelib_path(IntPtr raw, IntPtr namespace_);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_shared_library(IntPtr raw, IntPtr namespace_);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_irepository_get_version(IntPtr raw, IntPtr namespace_);
	}
}
