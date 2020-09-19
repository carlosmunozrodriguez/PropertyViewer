namespace PropertyViewer.Infrastructure.JsonSchema
{
    public class PropertyJson
    {
        public int Id { get; set; }

        public AddressJson? Address { get; set; }

        public PhysicalJson? Physical { get; set; }

        public FinancialJson? Financial { get; set; }
    }
}