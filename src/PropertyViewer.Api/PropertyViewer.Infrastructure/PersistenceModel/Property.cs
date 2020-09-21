using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyViewer.Infrastructure.PersistenceModel
{
    [Table("Properties")]
    public class Property
    {
        public int Id { get; set; }

        public string? Address { get; set; }

        public int? YearBuilt { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ListPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MonthlyRent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? GrossYield { get; set; }
    }
}