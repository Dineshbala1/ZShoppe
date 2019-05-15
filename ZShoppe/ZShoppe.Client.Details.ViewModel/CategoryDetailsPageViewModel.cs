using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Serilog;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.Categories.Contracts;
using ZShoppe.Client.Common.Contracts.Products;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.Details.ViewModels
{
    class CategoryDetailsPageViewModel : PageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;
        private readonly IPageDialogService _pageDialogService;
        private readonly ICategoryService _categoryService;

        private IEnumerable<ProductDetailsModel> _productDetailsModels;

        public IEnumerable<ProductDetailsModel> ProductDetailsModels
        {
            get => _productDetailsModels;
            set => SetProperty(ref _productDetailsModels, value);
        }

        public ICommand DetailsCommand { get; }
        public ICommand SortCommand { get; set; }
        public ICommand FilterCommand { get; set; }

        public CategoryDetailsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ILogger logger, ICategoryService categoryService) : base(navigationService, logger)
        {
            _navigationService = navigationService;
            _logger = logger;
            _categoryService = categoryService;
            _pageDialogService = pageDialogService;

            SortCommand = new DelegateCommand(async () => await ExecuteSortCommand());
            FilterCommand = new DelegateCommand(async () => await ExecuteFilterCommand());
            DetailsCommand = new DelegateCommand<ProductDetailsModel>(async (o) => { await ExecuteDetailsCommand(o); });
        }

        private async Task ExecuteSortCommand()
        {
            await _pageDialogService.DisplayAlertAsync("TODO", "No Implemented Yet", "Ok");
        }

        private async Task ExecuteFilterCommand()
        {
            await _pageDialogService.DisplayAlertAsync("TODO", "No Implemented Yet", "Ok");
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                IsBusy = true;
                if (parameters.ContainsKey(NavigationParameterKeys.CategoryDetails))
                {
                    var category = parameters.GetValue<CategoryModel>(NavigationParameterKeys.CategoryDetails);
                    if (category != null)
                    {
                        PageTitle = category.CategoryName;
                        await Task.Run(async () =>
                         {
                             ProductDetailsModels = await _categoryService.GetProductsAsync(category.CategoryId);
                         }).ConfigureAwait(false);
                    }
                }
                IsBusy = false;
            }
        }

        private async Task ExecuteDetailsCommand(ProductDetailsModel productDetailsModel)
        {
            if (productDetailsModel == null)
            {

            }

            await _navigationService.NavigateAsync(NavigationKeys.ProductDetailsPage,
                new NavigationParameters() {{NavigationParameterKeys.ProductDetails, productDetailsModel}});
        }
    }
}
