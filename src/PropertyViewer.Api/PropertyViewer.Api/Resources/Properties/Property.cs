namespace PropertyViewer.Api.Resources.Properties
{
    public class PropertyDto
    {
        public int? Id { get; set; }

        public string? Address { get; set; }
        
        public int? YearBuilt { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? MonthlyRent { get; set; }

        public decimal? GrossYield { get; set; }

        public bool Saved { get; set; }
    }
}