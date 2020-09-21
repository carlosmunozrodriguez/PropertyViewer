using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyViewer.Domain
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();

        Task<SavePropertyResult> SavePropertyAsync(int id);
    }
}