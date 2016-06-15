namespace SmartyStreets.USZipCodeApi
{
	using System.Collections;
	using System.Collections.Generic;

	public class Batch : ICollection<Lookup>
	{
		public const int MaxBatchSize = 100;
		private readonly Dictionary<string, Lookup> namedLookups;
		private readonly List<Lookup> allLookups;

		public Batch()
		{
			this.namedLookups = new Dictionary<string, Lookup>();
			this.allLookups = new List<Lookup>();
		}

		public void Add(Lookup lookup)
		{
			if (this.allLookups.Count >= MaxBatchSize)
				throw new BatchFullException("Batch size cannot exceed " + MaxBatchSize);

			this.allLookups.Add(lookup);

			var key = lookup.InputId;
			if (key == null)
				return;

			this.namedLookups[key] = lookup;
		}

		internal byte[] Serialize(ISerializer serializer)
		{
			return serializer.Serialize(this.allLookups);
		}

		public void Clear()
		{
			this.namedLookups.Clear();
			this.allLookups.Clear();
		}

		public bool Contains(Lookup item)
		{
			return this.allLookups.Contains(item);
		}

		public void CopyTo(Lookup[] array, int arrayIndex)
		{
			this.allLookups.CopyTo(array, arrayIndex);
		}

		public bool Remove(Lookup item)
		{
			this.namedLookups.Remove(item.InputId);
			return this.allLookups.Remove(item);
		}

		public IEnumerator<Lookup> GetEnumerator()
		{
			return this.allLookups.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public Lookup this[int index]
		{
			get { return this.allLookups[index]; }
		}

		public Lookup this[string value]
		{
			get { return this.namedLookups[value]; }
		}

		public int Count
		{
			get { return this.allLookups.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}
	}
}