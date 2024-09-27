namespace SmartyStreets.USEnrichmentApi.Universal
{
    using System;
    using System.IO;
    using System.Text;
    using SmartyStreets.USEnrichmentApi.Universal;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private byte[] results;

        public Lookup(string smartyKey = null, string dataSet = null, string dataSubset = null) : base(smartyKey, dataSet, dataSubset)
        {
        }

        public byte[] GetResults()
        {
            return results;
        }

        public void SetResults(byte[] results)
        {
            this.results = results;
        }

        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload)
        {
            using(var memoryStream = new MemoryStream())
            {
                payload.CopyTo(memoryStream);
                this.results = memoryStream.ToArray();
                string eTagJsonValue = "\"etag\":\"" + this.GetEtag() + "\",";
                this.results = InsertStringIntoByteArray(this.results, eTagJsonValue, 2);
            }
        }
        public static byte[] InsertStringIntoByteArray(byte[] originalValue, string stringToInsert, int insertIndex)
        {
            byte[] insertBytes = Encoding.UTF8.GetBytes(stringToInsert);
            byte[] newValue = new byte[originalValue.Length + insertBytes.Length];
            Array.Copy(originalValue, 0, newValue, 0, insertIndex);
            Array.Copy(insertBytes, 0, newValue, insertIndex, insertBytes.Length);
            Array.Copy(originalValue, insertIndex, newValue, insertIndex + insertBytes.Length, originalValue.Length - insertIndex);
            return newValue;
        }
    }
}