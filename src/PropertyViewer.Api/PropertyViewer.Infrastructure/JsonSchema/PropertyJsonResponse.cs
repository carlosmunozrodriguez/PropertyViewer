using System.Collections.Generic;

namespace PropertyViewer.Infrastructure.JsonSchema
{
    public class PropertyJsonResponse
    {
        public IEnumerable<PropertyJson> Properties { get; set; } = new List<PropertyJson>();
    }
}