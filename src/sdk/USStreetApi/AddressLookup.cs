using System;
using System.Runtime.Serialization;
using System.Collections;

namespace SmartyStreets
{
	[DataContract]
	public class AddressLookup
	{
		#region [ Fields ]

		private ArrayList Result { get; set; }

		private string InputId { get; set; }

		[DataMember(Name = "street")]
		private string Street { get; set; }

		[DataMember(Name = "street2")]
		private string Street2 { get; set; }

		[DataMember(Name = "secondary")]
		private string Secondary { get; set; }

		[DataMember(Name = "city")]
		private string City { get; set; }

		[DataMember(Name = "state")]
		private string State { get; set; }

		[DataMember(Name = "zipcode")]
		private string ZipCode { get; set; }

		[DataMember(Name = "lastline")]
		private string Lastline { get; set; }

		[DataMember(Name = "addressee")]
		private string Addressee { get; set; }

		[DataMember(Name = "urbanization")]
		private string Urbanization { get; set; }

		[DataMember(Name = "candidates")]
		private int maxCandidates;

		private int MaxCandidates
		{ 
			get { return this.maxCandidates; }
			set 
			{
				if (value > 0)
					this.maxCandidates = value;
				else
					throw new ArgumentException("Max candidates must be a positive integer.");
			}
				
		}

		#endregion

		#region [ Constructors ]

		public AddressLookup() {
			this.maxCandidates = 1;
			this.Result = new ArrayList();
		}

		public AddressLookup(String freeformAddress) {
			this();
			this.Street = freeformAddress;
		}

		#endregion

		public void addToResult(Candidate newCandidate) {
			this.Result.Add(newCandidate);
		}
	}
}

