using Prism.Navigation;
using Serilog;

namespace ZShoppe.Client.Common.ViewModels
{
    public abstract class PageViewModel : BaseViewModel, IConfirmNavigation
    {
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;

        private bool _isBusy;
        private string _pageTitle;
        private bool _isConnected;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }

        protected PageViewModel(INavigationService navigationService, ILogger logger)
        {
            _navigationService = navigationService;
            _logger = logger;
            //IsConnected = CrossConnectivity.Current.IsConnected;
            //CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            //CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
            base.OnNavigatedFrom(parameters);
        }

        public virtual bool CanNavigate(NavigationParameters parameters)
        {
            return true;
        }
    }
}
