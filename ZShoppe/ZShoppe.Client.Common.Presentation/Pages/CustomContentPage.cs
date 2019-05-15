using Prism.Navigation;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Pages
{
    public class CustomContentPage :ContentPage
    {
        private INavigatedAware _navigatedAware;

        public CustomContentPage()
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is INavigatedAware _bindingContext)
            {
                _navigatedAware = _bindingContext;
                var parameter = new NavigationParameters();
                parameter.AddInternalParameter(NavigationConstants.NavigationMode, NavigationMode.New);
                _navigatedAware.OnNavigatedTo(parameter);
            }
        }

        protected override void OnDisappearing()
        {
            if (BindingContext != null)
            {
                _navigatedAware.OnNavigatedFrom(null);
            }

            base.OnDisappearing();
        }
    }

    public class NavigationConstants
    {
        public const string NavigationMode = "__NavigationMode";
    }
}
