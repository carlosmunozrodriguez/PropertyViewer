namespace PropertyViewer.Domain
{
    public class Property
    {
        public Property(int id, string? address, int? yearBuilt, decimal? listPrice, decimal? monthlyRent, bool saved)
        {
            Id = id;
            Address = address;
            YearBuilt = yearBuilt;
            ListPrice = listPrice;
            MonthlyRent = monthlyRent;
            Saved = saved;
        }

        public int Id { get; }

        public string? Address { get; }

        public int? YearBuilt { get; }

        public decimal? ListPrice { get; }

        public decimal? MonthlyRent { get; }

        public decimal? GrossYield =>
            GrossYearCalculator.CalculateGrossYear(MonthlyRent, ListPrice);

        public bool Saved { get; }
    }
}