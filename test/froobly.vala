using GLib;

namespace Froobly
{
	public class Dogzilla
	{
		public string name { get; set; }

		public Dogzilla(string name)
		{
			this.name = name;
		}

		public string get_some(int arg)
		{
			return name + arg.to_string();
		}
	}
}
