using Xamarin.Forms;
using ZShoppe.Client.Common.Contracts.Products;

namespace ZShoppe.Client.WhiteboardHome.Views.Tiles
{
    class ProductTemplateSelector : DataTemplateSelector
    {

        public DataTemplate ProductTemplate { get; set; }

        public DataTemplate ProductEndTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is EndModel)
            {
                return ProductEndTemplate;
            }

            return ProductTemplate;
        }
    }
}
