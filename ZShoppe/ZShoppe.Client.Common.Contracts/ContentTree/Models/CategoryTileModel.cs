using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZShoppe.Client.Common.Contracts.Categories;

namespace ZShoppe.Client.Common.Contracts.ContentTree.Models
{
    public class CategoryTileModel : TileModel
    {
        private IEnumerable<CategoryModel> _categoriesModels;

        public IEnumerable<CategoryModel> CategoriesModels
        {
            get => _categoriesModels ?? Enumerable.Empty<CategoryModel>().ToArray();
            set => _categoriesModels = value;
        }
    }
}
