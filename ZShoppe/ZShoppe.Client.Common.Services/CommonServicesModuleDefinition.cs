using Prism.Ioc;
using Prism.Modularity;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories.Contracts;
using ZShoppe.Client.Common.Contracts.Products.Contracts;

namespace ZShoppe.Client.Common.Services
{
    public class CommonServicesModuleDefinition : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiHttpClientFactory, ApiHttpClientFactory>();
            containerRegistry.Register<ICategoryService, CategoryService>();
            containerRegistry.Register<IProductService, ProductService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
    }
}
