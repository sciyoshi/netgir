using System;
using System.Reflection;
using System.Reflection.Emit;

using GIRepository;

namespace NetGir.Generator
{
	public class AssemblyGenerator
	{
		Repository repository;
		string namespace_;
		
		public AssemblyGenerator(Repository repository, string namespace_)
		{
			this.repository = repository;
			this.namespace_ = namespace_;
			repository.Require(namespace_);
		}

		public AssemblyBuilder Build()
		{
			AssemblyName name = new AssemblyName(namespace_);
			name.Version = new Version(repository.GetVersion(namespace_));
			
			AssemblyBuilder b = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder mod = b.DefineDynamicModule(namespace_, namespace_ + ".dll");

			TypeBuilder glob = mod.DefineType("Globals", TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
			
			for (int i = 0; i < repository.GetNInfos(namespace_); i++) {
				BaseInfo info = repository.GetInfo(namespace_, i);

				if (info is ConstantInfo) {
					ConstantInfo c = info as ConstantInfo;
					Console.WriteLine("doing {0}", c.Name);
					var f = glob.DefineField(c.Name, TypeTagMapping.FromTag(c.Type.Tag), FieldAttributes.Static | FieldAttributes.Literal);
					object q = c.GetValue();
					Console.WriteLine("with {0}, {1}, {2}", c.Type.Tag, TypeTagMapping.FromTag(c.Type.Tag), q);
					f.SetConstant(q);
				}
			}
			glob.CreateType();
			b.Save(namespace_ + ".dll");			
			return b;
		}
	}
}
