using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZShoppe.Client.Common.Contracts.Products;

namespace ZShoppe.Client.Common.Contracts.Categories.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductDetailsModel>> GetProductsAsync(int categoryId);
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
    }
}
