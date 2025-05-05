namespace Country.Api.Models.Requests
{
    public class CountryRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Alpha2Code { get; set; } = string.Empty;
    }
}
