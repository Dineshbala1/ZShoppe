using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.Categories.Contracts;
using ZShoppe.Client.Common.Contracts.Products;

namespace ZShoppe.Client.Common.Services
{
    class CategoryService : ICategoryService
    {
        private readonly IApiHttpClientFactory _apiHttpClientFactory;
        private const string ProductsApiAddress = "product/category/{0}";

        public CategoryService(IApiHttpClientFactory apiHttpClientFactory)
        {
            _apiHttpClientFactory = apiHttpClientFactory;
        }

        public async Task<IEnumerable<ProductDetailsModel>> GetProductsAsync(int categoryId)
        {
            try
            {
                var productJson = await _apiHttpClientFactory.GetClient()
                    .GetStringAsync(string.Format(ProductsApiAddress, categoryId));

                return JsonConvert.DeserializeObject<IEnumerable<ProductDetailsModel>>(productJson);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
