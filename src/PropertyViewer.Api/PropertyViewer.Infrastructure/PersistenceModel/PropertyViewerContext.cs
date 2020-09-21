using Microsoft.EntityFrameworkCore;

namespace PropertyViewer.Infrastructure.PersistenceModel
{
    public class PropertyViewerContext : DbContext
    {
        public PropertyViewerContext(DbContextOptions<PropertyViewerContext> options)
            : base(options)
        { }

        public DbSet<Property>? Properties { get; set; }
    }
}