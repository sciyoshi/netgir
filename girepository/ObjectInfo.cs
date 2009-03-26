using System;
using System.Runtime.InteropServices;

namespace GIRepository
{
	public class ObjectInfo : RegisteredTypeInfo
	{
		public ObjectInfo(IntPtr raw) : base(raw)
		{
			Interfaces = new CollectionProperty<InterfaceInfo>(this, g_object_info_get_n_interfaces, g_object_info_get_interface);
			Fields = new CollectionProperty<FieldInfo>(this, g_object_info_get_n_fields, g_object_info_get_field);
			Properties = new CollectionProperty<PropertyInfo>(this, g_object_info_get_n_properties, g_object_info_get_property);
			Methods = new CollectionProperty<FunctionInfo>(this, g_object_info_get_n_methods, g_object_info_get_method);
			Signals = new CollectionProperty<SignalInfo>(this, g_object_info_get_n_signals, g_object_info_get_signal);
			VFuncs = new CollectionProperty<VFuncInfo>(this, g_object_info_get_n_vfuncs, g_object_info_get_vfunc);
		}

		public string TypeName {
			get { return GLib.Marshaller.Utf8PtrToString(g_object_info_get_type_name(Handle)); }
		}

		public string TypeInit {
			get { return GLib.Marshaller.Utf8PtrToString(g_object_info_get_type_init(Handle)); }
		}

		public bool Abstract {
			get { return g_object_info_get_abstract(Handle); }
		}

		public ObjectInfo Parent {
			get { return (ObjectInfo) GetOpaque(g_object_info_get_parent(Handle), false); }
		}
		
		public CollectionProperty<InterfaceInfo> Interfaces { get; private set; }

		public CollectionProperty<FieldInfo> Fields { get; private set; }

		public CollectionProperty<PropertyInfo> Properties { get; private set; }

		public CollectionProperty<FunctionInfo> Methods { get; private set; }

		public CollectionProperty<SignalInfo> Signals { get; private set; }

		public CollectionProperty<VFuncInfo> VFuncs { get; private set; }
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_type_name(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_type_init(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern bool g_object_info_get_abstract(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_parent(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_interfaces(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_interface(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_fields(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_field(IntPtr raw, int n);
		
		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_properties(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_property(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_methods(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_method(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_signals(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_signal(IntPtr raw, int n);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern int g_object_info_get_n_vfuncs(IntPtr raw);

		[DllImport("libgirepository-1.0-0.dll")]
		static extern IntPtr g_object_info_get_vfunc(IntPtr raw, int n);
	}
}
