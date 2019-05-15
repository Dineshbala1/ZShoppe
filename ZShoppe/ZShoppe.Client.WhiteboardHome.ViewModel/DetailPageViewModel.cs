using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Serilog;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.Contracts.PubSubEvents;
using ZShoppe.Client.Common.Contracts.Whiteboard.Services;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels
{
    class DetailPageViewModel : PageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;
        private readonly IEventAggregator _eventAggregator;
        private readonly IContentTreeService _contentTreeService;
        private readonly Func<int, TileModel, ITileProvider> _tileFactory;

        #region Fields

        private IList<ITileProvider> _tileModels;

        #endregion

        #region Properties

        public IList<ITileProvider> TileModels
        {
            get => _tileModels;
            set => SetProperty(ref _tileModels, value);
        }

        #endregion

        public ICommand AddToCartCommand { get; }

        public DetailPageViewModel(INavigationService navigationService, ILogger logger, IContentTreeService contentTreeService,
            Func<int, TileModel, ITileProvider> tileFactory, IEventAggregator eventAggregator) : base(navigationService, logger)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _contentTreeService = contentTreeService;
            _tileFactory = tileFactory;
            _logger = logger;

            AddToCartCommand = new DelegateCommand<ProductModel>(async (o) => await ExecuteAddToCartAsync(o));
            PageTitle = AppConstants.Home;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            _eventAggregator.GetEvent<CategoryDetailsEvent>().Unsubscribe(NavigateToCategoryDetailsAsync);
            //_eventAggregator.GetEvent<MasterNavigationEvent>().Unsubscribe(NavigateToMasterMenuItemsAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                IsBusy = true;
                var model = (await _contentTreeService.GetContentTree()).ToList();
                TileModels = model.Select(tileModel =>
                {
                    var tile = _tileFactory(tileModel.SortOrder, tileModel);
                    tile.ActivateTileCommand =
                        new DelegateCommand<object>(async (obj) => await ExecuteActivateCommandAsync(obj));
                    return tile;
                }).ToList();
                IsBusy = false;

                _eventAggregator.GetEvent<MasterNavigationEvent>().Subscribe(NavigateToMasterMenuItemsAsync);
            }

            _eventAggregator.GetEvent<CategoryDetailsEvent>().Subscribe(NavigateToCategoryDetailsAsync);
        }


        #region CommandExecutors

        private async void NavigateToCategoryDetailsAsync(CategoryModel obj)
        {
            await _navigationService.NavigateAsync(NavigationKeys.CategoryDetailsPage,
                new NavigationParameters() { { NavigationParameterKeys.CategoryDetails, obj } });
        }

        private async void NavigateToMasterMenuItemsAsync(string pageToNavigate)
        {
            await _navigationService.NavigateAsync(pageToNavigate);
            _eventAggregator.GetEvent<ShowHideMenuEvent>().Publish();
        }

        private async Task<bool> ExecuteActivateCommandAsync(object parameter)
        {
            await Task.Delay(1000);
            return false;
        }

        private async Task ExecuteAddToCartAsync(ProductModel model)
        {
            await _navigationService.NavigateAsync(NavigationKeys.ProductDetailsPage,
                new NavigationParameters() {{NavigationParameterKeys.ProductSkuId, model.SKU}});
        }

        #endregion
    }
}
