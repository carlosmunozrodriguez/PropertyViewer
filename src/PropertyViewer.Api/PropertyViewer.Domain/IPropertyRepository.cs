using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyViewer.Domain
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetProperties();
    }
}