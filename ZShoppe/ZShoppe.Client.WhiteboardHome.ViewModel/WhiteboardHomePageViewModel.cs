using Prism.Events;
using Prism.Navigation;
using Serilog;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels
{
    class WhiteboardHomePageViewModel : PageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;
        private readonly IEventAggregator _eventAggregator;

        public WhiteboardHomePageViewModel(INavigationService navigationService, ILogger logger,
            IEventAggregator eventAggregator) : base(navigationService, logger)
        {
            _logger = logger;
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            PageTitle = "This is from viewmodel";
        }
    }
}
