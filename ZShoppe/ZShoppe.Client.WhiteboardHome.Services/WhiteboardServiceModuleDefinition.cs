using Prism.Ioc;
using Prism.Modularity;
using ZShoppe.Client.Common.Contracts.Whiteboard.Services;

namespace ZShoppe.Client.WhiteboardHome.Services
{
    public class WhiteboardServiceModuleDefinition : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContentTreeService, ContentTreeService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
