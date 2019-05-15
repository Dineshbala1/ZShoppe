using Prism.Ioc;
using Prism.Modularity;

namespace ZShoppe.Client.Details.ViewModels
{
    public class DetailsViewModelModuleDefinition : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           containerRegistry.Register<CategoryDetailsPageViewModel>();
            containerRegistry.Register<ProductDetailsPageViewModel>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();
        }
    }
}
