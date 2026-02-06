namespace SmartyStreets
{
    public class AppendedHeader
    {
        public string Value { get; }
        public string Separator { get; }

        public AppendedHeader(string value, string separator)
        {
            this.Value = value;
            this.Separator = separator;
        }
    }
}
