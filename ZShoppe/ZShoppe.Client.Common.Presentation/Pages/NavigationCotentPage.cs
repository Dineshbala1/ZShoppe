using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Pages
{
    public class NavigationContentPage : ContentPage
    {

        public NavigationContentPage()
        {
            ToolbarItems.Add(new ToolbarItem() {Icon = "ic_launcher.png"});
            ToolbarItems.Add(new ToolbarItem() {Icon = "ic_launcher.png"});
        }

        protected override bool OnBackButtonPressed()
        {
            var canNavigate = true;

            var confirmNavigation = BindingContext as IConfirmNavigation;
            if (confirmNavigation != null)
            {
                canNavigate = true;
            }

            // if we can still navigate then check the Async version as well
            if (canNavigate)
            {
                var confirmNavigatioAsync = BindingContext as IConfirmNavigationAsync;
                if (confirmNavigatioAsync != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var canAsyncNavigate = true;
                        if (canAsyncNavigate)
                        {
                            // navigate back with the Xamarin navigation
                            if (Navigation.ModalStack.Any())
                            {
                                await Navigation.PopModalAsync(true);
                            }
                            else if (Navigation.NavigationStack.Any())
                            {
                                await Navigation.PopAsync(true);
                            }
                        }
                    });

                    // disable the go back
                    return true;
                }
            }

            return !canNavigate || base.OnBackButtonPressed();
        }
    }
}
