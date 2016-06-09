using System.Runtime.Serialization;

namespace SmartyStreets.USStreetApi
{
	[DataContract]
	public class Candidate
	{
		#region [ Fields ]

		[DataMember(Name = "input_index")]
		public int InputIndex { get; private set; }

		[DataMember(Name = "candidate_index")]
		public int CandidateIndex { get; private set; }

		[DataMember(Name = "addressee")]
		public string Addressee { get; private set; }

		[DataMember(Name = "delivery_line_1")]
		public string DeliveryLine1 { get; private set; }

		[DataMember(Name = "delivery_line_2")]
		public string DeliveryLine2 { get; private set; }

		[DataMember(Name = "last_line")]
		public string LastLine { get; private set; }

		[DataMember(Name = "delivery_point_barcode")]
		public string DeliveryPointBarcode { get; private set; }

		[DataMember(Name = "components")]
		public Components Components { get; private set; }

		[DataMember(Name = "metadata")]
		public Metadata Metadata { get; private set; }

		[DataMember(Name = "analysis")]
		public Analysis Analysis { get; private set; }

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