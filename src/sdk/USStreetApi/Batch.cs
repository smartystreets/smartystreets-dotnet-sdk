using System;
using System.Collections.Generic;

namespace SmartyStreets.USStreetApi
{
	public class Batch
	{
		public const int MAX_BATCH_SIZE = 100;
		public Dictionary<string, Lookup> NamedLookups { get; private set; }
		public List<Lookup> AllLookups { get; private set; }
		public bool StandardizeOnly { get; set; }
		public bool IncludeInvalid { get; set; }

		public Batch()
		{
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
			this.NamedLookups = new Dictionary<string, Lookup>();
			this.AllLookups = new List<Lookup>();
		}

		public void Add(Lookup newAddress)
		{
			if (this.AllLookups.Count >= MAX_BATCH_SIZE)
				throw new BatchFullException("Batch size cannot exceed " + MAX_BATCH_SIZE);

			this.AllLookups.Add(newAddress);

			string key = newAddress.InputId;
			if (key == null)
				return;

			//TODO: what way should we do it?
			//this.NamedLookups.Add(key, newAddress); - old way of doing it
			this.NamedLookups[key] = newAddress;
		}

		public void Reset()
		{
			Clear();
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
		}

		public void Clear()
		{
			this.NamedLookups.Clear();
			this.AllLookups.Clear();
		}

		public int Size() { return this.AllLookups.Count; }

		public List<Lookup>.Enumerator Enumerator() { return this.AllLookups.GetEnumerator(); }

		public Lookup Get(String inputId) { return this.NamedLookups[inputId]; } 

		public Lookup Get(int inputIndex) { return this.AllLookups[inputIndex]; }
	}
}

