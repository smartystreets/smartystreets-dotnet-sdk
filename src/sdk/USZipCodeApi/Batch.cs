namespace SmartyStreets.USZipCodeApi
{
	using System;
	using System.Collections.Generic;

	public class Batch
	{
		public const int MaxBatchSize = 100;
		public Dictionary<string, Lookup> NamedLookups { get; private set; }
		public List<Lookup> AllLookups { get; private set; }

		public Batch()
		{
			this.NamedLookups = new Dictionary<string, Lookup>();
			this.AllLookups = new List<Lookup>();
		}

		public void Add(Lookup lookup)
		{
			if (this.AllLookups.Count >= MaxBatchSize)
				throw new BatchFullException("Batch size cannot exceed " + MaxBatchSize);

			this.AllLookups.Add(lookup);

			var key = lookup.InputId;
			if (key == null)
				return;

			this.NamedLookups[key] = lookup;
		}

		public void Clear()
		{
			this.NamedLookups.Clear();
			this.AllLookups.Clear();
		}

		public int Size()
		{
			return this.AllLookups.Count;
		}

		public List<Lookup>.Enumerator Enumerator()
		{
			return this.AllLookups.GetEnumerator();
		}

		public Lookup Get(String inputId)
		{
			return this.NamedLookups[inputId];
		}

		public Lookup Get(int inputIndex)
		{
			return this.AllLookups[inputIndex];
		}
	}
}