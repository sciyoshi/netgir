using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetGir.Generator.Repository
{
	public class Generator
	{
		public static void Main(string[] args)
		{
			var assembly = System.Reflection.Assembly.LoadFile(args[0]);

			foreach (var module in assembly.GetModules(false)) {
				foreach (var type in module.GetTypes()) {
					Console.WriteLine(type.FullName);
				}
			}
		}
	}
}
