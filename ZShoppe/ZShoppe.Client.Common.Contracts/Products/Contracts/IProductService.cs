using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZShoppe.Client.Common.Contracts.Products.Contracts
{
    public interface IProductService
    {
        Task<ProductDetailsModel> GetProductDetailsAsync(string productSkuCode);
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task PostProductReviewAsync();
        Task UpdateProductReviewAsync();
    }
}
