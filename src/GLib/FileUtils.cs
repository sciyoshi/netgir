// GLib.FileUtils.cs - GFileUtils class implementation
//
// Author: Martin Baulig <martin@gnome.org>
//
// Copyright (c) 2002 Ximian, Inc
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the Lesser GNU General 
// Public License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.

using GObject;

namespace GLib {

	using System;
	using System.Text;
	using System.Runtime.InteropServices;

	public class FileUtils
	{
		[DllImport("libglib-2.0-0.dll")]
		extern static bool g_file_get_contents (IntPtr filename, out IntPtr contents, out int length, out IntPtr error);

		public static string GetFileContents (string filename)
		{
			int length;
			IntPtr contents, error;
			IntPtr native_filename = Marshaller.StringToPtrGStrdup (filename);

			if (!g_file_get_contents (native_filename, out contents, out length, out error))
				throw new GException (error);

			Marshaller.Free (native_filename);
			return Marshaller.Utf8PtrToString (contents);
		}


		[DllImport("libglib-2.0-0.dll")]
		static extern IntPtr g_filename_to_utf8 (IntPtr mem, int len, IntPtr read, out IntPtr written, out IntPtr error);

		public static string FilenamePtrToString (IntPtr ptr) 
		{
			if (ptr == IntPtr.Zero) return null;
			
			IntPtr dummy, error;
			IntPtr utf8 = g_filename_to_utf8 (ptr, -1, IntPtr.Zero, out dummy, out error);
			if (error != IntPtr.Zero)
				throw new GLib.GException (error);
			return GObject.Marshaller.Utf8PtrToString (utf8);
		}

		public static string FilenamePtrToStringGFree (IntPtr ptr) 
		{
			string ret = FilenamePtrToString (ptr);
			GObject.Marshaller.Free (ptr);
			return ret;
		}

		[DllImport("libglib-2.0-0.dll")]
		static extern IntPtr g_filename_from_utf8 (IntPtr mem, int len, IntPtr read, out IntPtr written, out IntPtr error);

		public static IntPtr StringToFilenamePtr (string str) 
		{
			if (str == null)
				return IntPtr.Zero;

			IntPtr dummy, error;
			IntPtr utf8 = GObject.Marshaller.StringToPtrGStrdup (str);
			IntPtr result = g_filename_from_utf8 (utf8, -1, IntPtr.Zero, out dummy, out error);
			GObject.Marshaller.Free (utf8);
			if (error != IntPtr.Zero)
				throw new GException (error);

			return result;
		}

		
		private FileUtils () {}
	}
}
