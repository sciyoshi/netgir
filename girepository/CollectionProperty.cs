using System;

namespace GIRepository
{
	public class CollectionProperty<T> where T : BaseInfo
	{
		readonly BaseInfo info;
		readonly Func<IntPtr, int> counter;
		readonly Func<IntPtr, int, IntPtr> getter;
		
		internal CollectionProperty(BaseInfo info, Func<IntPtr, int> counter, Func<IntPtr, int, IntPtr> getter)
		{
			this.info = info;
			this.counter = counter;
			this.getter = getter;
		}
		
		public T this[int n] {
			get {
				return (T) BaseInfo.GetOpaque(getter(info.Handle, n), false);
			}
		}
		
		public int Count {
			get {
				return counter(info.Handle);
			}
		}
	}
}
