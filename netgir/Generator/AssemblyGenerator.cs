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
					var f = glob.DefineField(c.Name, TypeTagMapping.FromTag(c.Type.Tag), FieldAttributes.Static | FieldAttributes.Literal);
					object q = c.GetValue();
					f.SetConstant(q);
				} else if (info is ObjectInfo) {
					ObjectInfo c = info as ObjectInfo;
					TypeBuilder x = mod.DefineType(c.Name, TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.Public | TypeAttributes.Class);
					x.SetParent(Assembly.Load(c.Parent.Typelib.Namespace).GetType(c.Name));
					Console.WriteLine("doing {0}", c.Name);
					Console.WriteLine("parent: {0}", c.Parent.Name);
					Console.WriteLine("parent: {0}", c.Parent.TypeInit);
					Console.WriteLine("parent: {0}", c.Parent.Typelib);
					x.CreateType();
				}
			}
			glob.CreateType();
			b.Save(namespace_ + ".dll");			
			return b;
		}
	}
}
