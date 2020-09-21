namespace PropertyViewer.Domain
{
    public static class GrossYearCalculator
    {
        public static decimal? CalculateGrossYear(decimal? monthlyRent, decimal? listPrice) =>
            monthlyRent != null && listPrice != null && listPrice != 0
                ? monthlyRent * 12 / listPrice
                : null;
    }
}