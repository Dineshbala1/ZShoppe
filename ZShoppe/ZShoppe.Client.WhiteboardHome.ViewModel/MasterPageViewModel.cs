using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.PubSubEvents;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels
{
    class MasterPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private IEnumerable<string> _menuItems;

        public IEnumerable<string> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ICommand NavigateToMenuCommand { get; }

        public MasterPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            NavigateToMenuCommand = new DelegateCommand<string>(ExecuteNavigateToMenuCommand);
        }

        private void ExecuteNavigateToMenuCommand(string o)
        {
            var pageToNavigate = string.Empty;
            switch (o)
            {
                case "My Account":
                    pageToNavigate = NavigationKeys.CartDetailsPage;
                    break;
                case "Profile":
                    break;
                case "My Cart":
                    pageToNavigate = NavigationKeys.CartDetailsPage;
                    break;
                case "Orders":
                    pageToNavigate = NavigationKeys.CartDetailsPage;
                    break;
                case "My Wishlist":
                    pageToNavigate = NavigationKeys.CartDetailsPage;
                    break;
            }

            _eventAggregator.GetEvent<MasterNavigationEvent>().Publish(pageToNavigate);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                MenuItems = new List<string>
                {
                    "Profile",
                    "Orders",
                    "My Cart",
                    "My Wishlist",
                    "My Account"
                };
            }
        }
    }
}
