using Blazui.Docs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazui.Docs.Services
{
    public class ProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient("product");
        }

        public Task<List<ProductModel>> GetProductsAsync()
        {
            return httpClient.GetJsonAsync<List<ProductModel>>("api/products");
        }

        public Task<List<VersionModel>> GetVersionsAsync(int id)
        {
            return httpClient.GetJsonAsync<List<VersionModel>>($"api/products/{id}/versions");
        }

        public Task<List<StepModel>> GetQuickStartStepsAsync(int versionId)
        {
            return httpClient.GetJsonAsync<List<StepModel>>($"api/products/0/versions/{versionId}/quickstarts");
        }

        public Task<List<ComponentModel>> GetComponentsAsync(int versionId)
        {
            return httpClient.GetJsonAsync<List<ComponentModel>>($"api/products/0/versions/{versionId}/components");
        }
    }
}
