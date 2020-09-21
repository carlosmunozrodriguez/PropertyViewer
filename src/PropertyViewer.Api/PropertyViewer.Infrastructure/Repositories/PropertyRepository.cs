using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PropertyViewer.Domain;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PropertyViewer.Infrastructure.JsonSchema;
using PropertyViewer.Infrastructure.PersistenceModel;
using Property = PropertyViewer.Domain.Property;

namespace PropertyViewer.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository, IDisposable
    {
        private readonly PropertyViewerContext _context;
        private readonly HttpClient _httpClient = new HttpClient();

        public PropertyRepository(IConfiguration configuration, PropertyViewerContext context)
        {
            _httpClient.BaseAddress = new Uri(configuration["DataSourceUrl"]);
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            var propertiesFromJson = await GetPropertiesFromJsonAsync();

            var savedIds = await _context.Properties!.Select(x => x.Id).ToListAsync();

            return propertiesFromJson
                .Select(x => new Property(
                    x.Id,
                    x.Address?.ToString(),
                    x.Physical?.YearBuilt,
                    x.Financial?.ListPrice,
                    x.Financial?.MonthlyRent,
                    savedIds.Contains(x.Id))
                );
        }

        public async Task<SavePropertyResult> SavePropertyAsync(int id)
        {
            var propertiesFromJson = await GetPropertiesFromJsonAsync();

            var property = propertiesFromJson.Find(x => x.Id == id);

            if (property is null)
            {
                return new IdNotFoundResult(id);
            }

            var alreadyExists = await _context.Properties!.AnyAsync(x => x.Id == id);

            if (alreadyExists)
            {
                return new AlreadySavedResult(id);
            }

            var newProperty = new PersistenceModel.Property
            {
                Id = property.Id,
                Address = property.Address?.ToString(),
                YearBuilt = property.Physical?.YearBuilt,
                ListPrice = property.Financial?.ListPrice,
                MonthlyRent = property.Financial?.MonthlyRent,
            };
            newProperty.GrossYield = GrossYearCalculator.CalculateGrossYear(newProperty.MonthlyRent, newProperty.ListPrice);

            await _context.Properties!.AddAsync(newProperty);
            await _context.SaveChangesAsync();

            return new SuccessSavePropertyResult();
        }

        private async Task<List<PropertyJson>> GetPropertiesFromJsonAsync()
        {
            var responseMessage = await _httpClient.GetAsync("");
            var responseStream = await responseMessage.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<PropertyJsonResponse>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result.Properties.ToList();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}