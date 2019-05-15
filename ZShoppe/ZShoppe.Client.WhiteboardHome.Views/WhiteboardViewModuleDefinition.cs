using Prism.Ioc;
using Prism.Modularity;

namespace ZShoppe.Client.WhiteboardHome.Views
{
    public class WhiteboardViewModuleDefinition : IModule
    {
       
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WhiteboardHomePage>();
            containerRegistry.RegisterForNavigation<DetailPage>();
            containerRegistry.RegisterForNavigation<MasterPage>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
    }
}
