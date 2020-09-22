using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyViewer.Domain;

namespace PropertyViewer.Api.Resources.Properties
{
    [ApiController]
    [Route("properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertiesController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> Get() =>
            (await _propertyRepository.GetPropertiesAsync())
            .Select(x => new PropertyDto
            {
                Id = x.Id,
                Address = x.Address,
                YearBuilt = x.YearBuilt,
                ListPrice = x.ListPrice,
                MonthlyRent = x.MonthlyRent,
                GrossYield = x.GrossYield,
                Saved = x.Saved
            }).ToArray();

        [HttpPost("{id}/save")]
        public async Task<IActionResult> Post(int id)
        {
            var result = await _propertyRepository.SavePropertyAsync(id);

            return result switch
            {
                IdNotFoundResult _ => NotFound(result),
                AlreadySavedResult _ => BadRequest(result),
                SuccessSavePropertyResult _ => Ok(result),
                _ => BadRequest(result)
            };
        }
    }
}