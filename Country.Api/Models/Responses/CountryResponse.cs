namespace Country.Api.Models.Responses
{
    public class CountryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Alpha2Code { get; set; } = string.Empty;
    }
}
