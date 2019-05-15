using System;
using System.Collections.Generic;
using System.Text;

namespace ZShoppe.Client.Common.Contracts.Products
{
    public class ProductDetailsModel
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductMetaDescription { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public double Discount { get; set; }
        public double DiscountedPrice { get; set; }
        public double OriginalPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryName { get; set; }
        public List<object> ProductReviews { get; set; }
        public double Rating { get; set; }
        public double ReviewsCount { get; set; }
    }

}
