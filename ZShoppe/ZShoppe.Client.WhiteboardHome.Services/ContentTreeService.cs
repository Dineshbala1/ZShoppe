using System;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.Contracts.Whiteboard.Services;

namespace ZShoppe.Client.WhiteboardHome.Services
{
    class ContentTreeService : IContentTreeService
    {

        private const string BaseAddress = "v2/contentTree";
        private readonly ILogger _logger;
        private readonly IApiHttpClientFactory _apiHttpClientFactory;

        public ContentTreeService(IApiHttpClientFactory apiHttpClientFactory, ILogger logger)
        {
            _apiHttpClientFactory = apiHttpClientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<TileModel>> GetContentTree()
        {
            _logger.Verbose($"{nameof(GetContentTree)} -Entering");
            var contentTreeCollection = new ContentTreeModel();

            try
            {
                var secondCollection = new List<AdvertisementModel>
                {
                    new AdvertisementModel
                    {
                        AdImageUrl =
                            "http://img8.flixcart.com/www/promos/new/20130527-230650-homepage-banner-tuesday-sale-electronics.jpg"
                    },
                    new AdvertisementModel
                    {
                        AdImageUrl =
                            "https://www.ionwe.com/blog/wp-content/uploads/2018/01/Build-your-Multi-vendor-eCommerce-website-with-ionwe-eCommerce-solution-1.jpg"
                    },
                    new AdvertisementModel
                    {
                        AdImageUrl =
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeBcsbkpns9JATWzQOcTxuU115u-VZLPQR3U0NXB96Ml3Z5G42"
                    },
                    new AdvertisementModel
                    {
                        AdImageUrl = "http://yescoupons.in/wp-content/uploads/2017/09/Amazon-Offers-on-Electronics.jpg"
                    },
                    new AdvertisementModel {AdImageUrl = "https://images.financialexpress.com/2016/10/flipkart-5.jpg"}
                };

                contentTreeCollection = new ContentTreeModel
                {
                    Tiles = new List<TileModel>()
                    {
                        new ProductTileModel()
                        {
                            DisplayName = "Today's Deal",
                            Enabled = true,
                            FeatureBackgroundImage = "a.jpg",
                            FeatureName = "DailyDeal",
                            SortOrder = 6,
                            ProductModels = await GetProduct()
                        },

                        new AdvertismentTileModel()
                        {
                            DisplayName = "Advertisment",
                            Enabled = true,
                            FeatureBackgroundImage = "a.jpg",
                            FeatureName = "Advertisment",
                            SortOrder = 1,
                            AdvertisementModels = secondCollection
                        },

                        new CategoryTileModel()
                        {
                            DisplayName = "Product Categories",
                            Enabled = true,
                            FeatureBackgroundImage = "a.jpg",
                            FeatureName = "Categories",
                            SortOrder = 2,
                            CategoriesModels = await GetCategories()
                        },
                    }
                };
            }
            catch (Exception e)
            {
                _logger.Error(e, $"{nameof(GetContentTree)}-{e.Message}");
            }

            _logger.Verbose($"{nameof(GetContentTree)} -Exiting");
            return contentTreeCollection.Tiles.OrderBy(row => row.SortOrder).ToList();
        }

        private async Task<IEnumerable<ProductModel>> GetProduct()
        {
            _logger.Verbose($"{nameof(GetProduct)} -Entering");
            IEnumerable<ProductModel> productModels = new List<ProductModel>();

            try
            {
                var result = await _apiHttpClientFactory.GetClient().GetStringAsync("product");
                productModels = JsonConvert.DeserializeObject<List<ProductModel>>(result);
            }
            catch (Exception e)
            {
                _logger.Error(e, $"{nameof(GetProduct)}-{e.Message}");
            }

            _logger.Verbose($"{nameof(GetProduct)} -Exiting");
            return productModels;
        }

        private async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            _logger.Verbose($"{nameof(GetCategories)} -Entering");
            IEnumerable<CategoryModel> categoryModels = new List<CategoryModel>();

            try
            {
                var result = await _apiHttpClientFactory.GetClient().GetStringAsync("product/categories");
                categoryModels = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(result);
            }
            catch (Exception e)
            {
                _logger.Error(e, $"{nameof(GetCategories)}-{e.Message}");
            }

            _logger.Verbose($"{nameof(GetCategories)} -Exiting");
            return categoryModels;
        }
    }
}
