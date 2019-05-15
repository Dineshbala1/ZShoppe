using Prism.Mvvm;
using Prism.Navigation;

namespace ZShoppe.Client.Common.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigatedAware
    {
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
