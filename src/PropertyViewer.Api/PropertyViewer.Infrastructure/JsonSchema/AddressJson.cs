using System;

namespace PropertyViewer.Infrastructure.JsonSchema
{
    public class AddressJson
    {
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public string? ZipPlus4 { get; set; }

        public override string ToString() =>
            $"{Address1}{Line2}{Line3}";

        private string? Line2 =>
            string.IsNullOrEmpty(Address2) ? null
            : Environment.NewLine + Address2;

        private string Line3 => $"{Environment.NewLine}{City}, {State} {FullZip}, {Country}";

        private string? FullZip =>
            string.IsNullOrEmpty(Zip) ? null
            : string.IsNullOrEmpty(ZipPlus4) ? Zip
            : $"{Zip}-{ZipPlus4}";
    }
}