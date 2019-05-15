using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels.Tiles
{
    class ProductTileViewModel : BaseViewModel, IProductTile
    {
        public bool Enabled { get; set; }
        public ICommand ProductTapcommand { get; }
        public ICommand ActivateTileCommand { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }
        public string DisplayName { get; set; }
        public string FeatureBackgroundImage { get; set; }
        public string Url { get; set; }

        public ProductTileViewModel(int index, ProductTileModel model)
        {
            var localmodel = model.ProductModels.Take(10).ToList();
            localmodel.Add(new EndModel() { EndMessage = "ViewAll" });

            DisplayName = model.DisplayName;
            FeatureBackgroundImage = model.FeatureBackgroundImage;
            Url = model.Url;
            ProductModels = localmodel;
            ProductTapcommand = new DelegateCommand<ProductModel>(ExecuteProductTap);
        }

        private void ExecuteProductTap(ProductModel obj)
        {
            if (obj != null)
            {

            }
        }
    }
}
