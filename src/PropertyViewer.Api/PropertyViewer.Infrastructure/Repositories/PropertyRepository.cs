using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PropertyViewer.Domain;
using System.Text.Json;
using PropertyViewer.Infrastructure.JsonSchema;

namespace PropertyViewer.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository, IDisposable
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public PropertyRepository(IConfiguration configuration)
        {
            _httpClient.BaseAddress = new Uri(configuration["DataSourceUrl"]);
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var responseMessage = await _httpClient.GetAsync("");
            var responseStream = await responseMessage.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<PropertyJsonResponse>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result.Properties
                .Select(x => new Property(x.Id, x.Address?.ToString(), x.Physical?.YearBuilt, x.Financial?.ListPrice, x.Financial?.MonthlyRent));
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}