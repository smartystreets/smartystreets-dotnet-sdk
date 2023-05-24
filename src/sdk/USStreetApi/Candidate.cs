namespace SmartyStreets.USStreetApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Candidate
	{
		#region [ Fields ]

		[DataMember(Name = "input_id")]
		public string InputId { get; set; }

		[DataMember(Name = "input_index")]
		public int InputIndex { get; set; }

		[DataMember(Name = "candidate_index")]
		public int CandidateIndex { get; set; }

		[DataMember(Name = "addressee")]
		public string Addressee { get; set; }

		[DataMember(Name = "delivery_line_1")]
		public string DeliveryLine1 { get; set; }

		[DataMember(Name = "delivery_line_2")]
		public string DeliveryLine2 { get; set; }

		[DataMember(Name = "last_line")]
		public string LastLine { get; set; }

		[DataMember(Name = "delivery_point_barcode")]
		public string DeliveryPointBarcode { get; set; }

		[DataMember(Name = "smarty_key")]
		public string SmartyKey{ get; set; }

		[DataMember(Name = "components")]
		public Components Components { get; set; }

		[DataMember(Name = "metadata")]
		public Metadata Metadata { get; set; }

		[DataMember(Name = "analysis")]
		public Analysis Analysis { get; set; }

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