using Xamarin.Forms;
using ZShoppe.Client.Common.Contracts;

namespace ZShoppe.Client.WhiteboardHome.Views.Tiles
{
    class TileTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TileTemplate { get; set; }

        public DataTemplate AdvertismentTileTemplate { get; set; }

        public DataTemplate ProductTileTemplate { get; set; }

        public DataTemplate CategoryTileTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is IProductTile)
            {
                return ProductTileTemplate;
            }

            if (item is IAdvertisementTile)
            {
                return AdvertismentTileTemplate;
            }

            return CategoryTileTemplate;
        }
    }

}
