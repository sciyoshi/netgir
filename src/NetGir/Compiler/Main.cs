using System;

using GIRepository;

namespace NetGir
{
	public class NetGir
	{
		public static void Main(string[] args)
		{
			GObject.GType.Init();

			var repo = Repository.GetDefault();

			Console.WriteLine("Got Repository -------- {0}", repo);
			Console.WriteLine("Repository search path:");
			foreach (string path in Repository.GetSearchPath()) {
				Console.WriteLine("  - {0}", path);
			}

			Console.WriteLine("Loading typelib...");

			new Generator.AssemblyGenerator(repo, args[0]).Build();
			/*
			
			var gir = repo.Require(args[0], RepositoryLoadFlags.None);

			Console.WriteLine("Registered ------------ {0}", repo.IsRegistered(gir.GetNamespace()));
			Console.WriteLine("Typelib path ---------- {0}", repo.GetTypelibPath(gir.GetNamespace()));
			Console.WriteLine("Shared library -------- {0}", repo.GetSharedLibrary(gir.GetNamespace()));
			Console.WriteLine("Version --------------- {0}", repo.GetVersion(gir.GetNamespace()));
			Console.WriteLine("Dependencies:");
			foreach (string dep in repo.GetDependencies(gir.GetNamespace())) {
				Console.WriteLine("  - {0}", dep);
			}
			Console.WriteLine("NInfos ---------------- {0}", repo.GetNInfos(gir.GetNamespace()));
			for (int i = 0; i < repo.GetNInfos(gir.GetNamespace()); i++) {
				BaseInfo info = repo.GetInfo(gir.GetNamespace(), i);
				string name = info != null ? info.Name : null;
				Console.WriteLine("Info {0} ---------------- {1} - {2}", i, info, name);
				if (info is ConstantInfo) {
					TypeInfo type = (info as ConstantInfo).Type;
					int size;
					Argument arg = (info as ConstantInfo).GetValue(out size);
					Console.WriteLine("     {0}, {1}, {2}", (type != null ? type.Tag : 0), size, arg.VInt32);
				}
			}*/
		}
	}
}