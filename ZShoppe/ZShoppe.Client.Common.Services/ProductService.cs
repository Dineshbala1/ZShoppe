using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.Contracts.Products.Contracts;

namespace ZShoppe.Client.Common.Services
{
    class ProductService : IProductService
    {
        private const string BaseAddress = "product/";
        private readonly IApiHttpClientFactory _apiHttpClientFactory;
        private readonly ILogger _logger;

        public ProductService(IApiHttpClientFactory apiHttpClientFactory, ILogger logger)
        {
            _apiHttpClientFactory = apiHttpClientFactory;
            _logger = logger;
        }

        public async Task<ProductDetailsModel> GetProductDetailsAsync(string productSkuCode)
        {
            try
            {
                var jsonString =
                    await _apiHttpClientFactory.GetClient().GetStringAsync($"{BaseAddress}{productSkuCode}");
                return JsonConvert.DeserializeObject<ProductDetailsModel>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task PostProductReviewAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductReviewAsync()
        {
            throw new NotImplementedException();
        }
    }
}
