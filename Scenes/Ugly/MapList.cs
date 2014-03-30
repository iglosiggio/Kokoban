using System;
using System.Collections;

namespace Kokoban.Ugly
{
	public class MapList : IList
	{
		#region IList implementation
		public int Add (object value)
		{
			throw new NotImplementedException ();
		}
		public bool Contains (object value)
		{
			if (value.GetType () == typeof(Int32) && (Int32)value >= 0 && (Int32)value < Global.Maps.Count)
				return true;
			return false;
		}
		public void Clear ()
		{
			throw new NotImplementedException ();
		}
		public int IndexOf (object value)
		{
			throw new NotImplementedException ();
		}
		public void Insert (int index, object value)
		{
			throw new NotImplementedException ();
		}
		public void Remove (object value)
		{
			throw new NotImplementedException ();
		}
		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}
		public object this [int index] {
			get {
				if (index >= 0 && index < Global.Maps.Count)
					return index;
				throw new IndexOutOfRangeException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public bool IsReadOnly {
			get {
				return false;
			}
		}
		public bool IsFixedSize {
			get {
				return false;
			}
		}
		#endregion
		#region ICollection implementation
		public void CopyTo (Array array, int index)
		{
			((ICollection)Global.Maps).CopyTo (array, index);
		}
		public int Count {
			get {
				return Global.Maps.Count;
			}
		}
		public object SyncRoot {
			get {
				return ((ICollection)Global.Maps).SyncRoot;
			}
		}
		public bool IsSynchronized {
			get {
				return ((ICollection)Global.Maps).IsSynchronized;
			}
		}
		#endregion
		#region IEnumerable implementation
		public IEnumerator GetEnumerator ()
		{
			return Global.Maps.GetEnumerator ();
		}
		#endregion
	}
}

