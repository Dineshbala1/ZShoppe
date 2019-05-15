using System;
using Prism.Ioc;
using Prism.Modularity;

namespace ZShoppe.Client.Details.Views
{
    public class DetailsViewModuleDefinition : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CategoryDetailsPage>();
            containerRegistry.RegisterForNavigation<ProductDetailsPage>();
            containerRegistry.RegisterForNavigation<CartDetailsPage>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
