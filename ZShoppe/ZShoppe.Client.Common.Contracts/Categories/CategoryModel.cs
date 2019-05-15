using System;
using System.Collections.Generic;
using System.Text;

namespace ZShoppe.Client.Common.Contracts.Categories
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public object Subcategories { get; set; }
    }
}
