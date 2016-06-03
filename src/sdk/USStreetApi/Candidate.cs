using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Candidate
	{
		#region [ Fields ]

		[DataMember(Name = "input_index")]
		public string InputIndex { get; private set; }

		[DataMember(Name = "candidate_index")]
		private int CandidateIndex { get; private set; }

		[DataMember(Name = "addressee")]
		private string Addressee { get; private set; }

		[DataMember(Name = "delivery_line_1")]
		private string DeliveryLine1 { get; private set; }

		[DataMember(Name = "delivery_line_2")]
		private string DeliveryLine2 { get; private set; }

		[DataMember(Name = "last_line")]
		private string LastLine { get; private set; }

		[DataMember(Name = "delivery_point_barcode")]
		private string DeliveryPointBarcode { get; private set; }

		[DataMember(Name = "components")]
		private Components Components { get; private set; }

		[DataMember(Name = "metadata")]
		private Metadata Metadata { get; private set; }

		[DataMember(Name = "analysis")]
		private Analysis Analysis { get; private set; }

		#endregion

		public Candidate()
		{
		}

		public Candidate(int inputIndex)
		{
			this.InputIndex = inputIndex;
		}
	}
}