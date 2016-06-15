namespace SmartyStreets.USStreetApi
{
	using System.Collections;
	using System.Collections.Generic;

	public class Batch : ICollection<Lookup>
	{
		public const int MaxBatchSize = 100;
		private readonly Dictionary<string, Lookup> namedLookups;
		private readonly List<Lookup> allLookups;
		public bool StandardizeOnly { get; set; }
		public bool IncludeInvalid { get; set; }

		public Batch()
		{
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
			this.namedLookups = new Dictionary<string, Lookup>();
			this.allLookups = new List<Lookup>();
		}

		internal byte[] Serialize(ISerializer serializer)
		{
			return serializer.Serialize(this.allLookups);
		}

		public void Add(Lookup newAddress)
		{
			if (this.allLookups.Count >= MaxBatchSize)
				throw new BatchFullException("Batch size cannot exceed " + MaxBatchSize);

			this.allLookups.Add(newAddress);

			var key = newAddress.InputId;
			if (key == null)
				return;

			this.namedLookups[key] = newAddress;
		}

		public void Reset()
		{
			this.Clear();
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
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

		public Lookup this[string value]
		{
			get { return this.namedLookups[value]; }
		}

		public Lookup this[int index]
		{
			get { return this.allLookups[index]; }
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