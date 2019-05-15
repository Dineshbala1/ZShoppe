using System.Collections.Generic;
using Prism.Navigation;
using Serilog;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.Contracts.Products.Contracts;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.Details.ViewModels
{
    class ProductDetailsPageViewModel : PageViewModel
    {
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;
        private ProductDetailsModel _productDetails;
        private IEnumerable<RotatorItem> _rotatorItems;
        private readonly IProductService _productService;

        public ProductDetailsModel ProductDetails
        {
            get => _productDetails;
            set => SetProperty(ref _productDetails, value);
        }

        public IEnumerable<RotatorItem> RotatorItems
        {
            get => _rotatorItems;
            set => SetProperty(ref _rotatorItems, value);
        }

        public ProductDetailsPageViewModel(INavigationService navigationService, ILogger logger, IProductService productService) : base(
            navigationService, logger)
        {
            _navigationService = navigationService;
            _productService = productService;
            _logger = logger;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsBusy = true;
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                if (parameters.ContainsKey(NavigationParameterKeys.ProductDetails))
                {
                    ProductDetails = parameters.GetValue<ProductDetailsModel>(NavigationParameterKeys.ProductDetails);
                }
                else if (parameters.ContainsKey(NavigationParameterKeys.ProductSkuId))
                {
                    string productSkuId = parameters.GetValue<string>(NavigationParameterKeys.ProductSkuId);
                    ProductDetails = await _productService.GetProductDetailsAsync(productSkuId);
                }

                PageTitle = ProductDetails != null ? ProductDetails.ProductName : string.Empty;
            }

            RotatorItems = new List<RotatorItem>()
            {
                new RotatorItem()
                {
                    Name =
                        "http://img8.flixcart.com/www/promos/new/20130527-230650-homepage-banner-tuesday-sale-electronics.jpg"

                }
            };

            IsBusy = false;
        }
    }

    public class RotatorItem
    {
        public string Name { get; set; }
    }
}
