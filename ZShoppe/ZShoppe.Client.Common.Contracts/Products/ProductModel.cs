using ZShoppe.Client.Common.Contracts.ContentTree.Models;

namespace ZShoppe.Client.Common.Contracts.Products
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryName { get; set; }
        public double Discount { get; set; }
        public double DiscountedPrice { get; set; }
        public double OriginalPrice { get; set; }
        public bool Enabled { get; set; }
    }

    public class EndModel : ProductModel
    {
        public string EndMessage { get; set; }
    }
}
