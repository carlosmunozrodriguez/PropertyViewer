namespace PropertyViewer.Domain
{
    public class Property
    {
        public Property(int id, string? address, int? yearBuilt, decimal? listPrice, decimal? monthlyRent)
        {
            Id = id;
            Address = address;
            YearBuilt = yearBuilt;
            ListPrice = listPrice;
            MonthlyRent = monthlyRent;
        }

        public int Id { get; set; }

        public string? Address { get; }

        public int? YearBuilt { get; }

        public decimal? ListPrice { get; }

        public decimal? MonthlyRent { get; }

        public decimal? GrossYield =>
            MonthlyRent != null && ListPrice != null && ListPrice != 0
                ? MonthlyRent * 12 / ListPrice
                : null;
    }
}