using System.Collections.Generic;
using System.Linq;
using ZShoppe.Client.Common.Contracts.Products;

namespace ZShoppe.Client.Common.Contracts.ContentTree.Models
{
    public class ProductTileModel : TileModel
    {
        private IEnumerable<ProductModel> _productModels;

        public IEnumerable<ProductModel> ProductModels
        {
            get => _productModels ?? Enumerable.Empty<ProductModel>();
            set => _productModels = value;
        }
    }
}
