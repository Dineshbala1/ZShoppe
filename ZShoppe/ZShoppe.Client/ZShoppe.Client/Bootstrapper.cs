using System;
using System.Globalization;
using System.Reflection;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Unity;
using Serilog;
using Syncfusion.Licensing;
using Xamarin.Forms;
using ZShoppe.Client.Common.Services;
using ZShoppe.Client.Details.ViewModels;
using ZShoppe.Client.Details.Views;
using ZShoppe.Client.WhiteboardHome.Services;
using ZShoppe.Client.WhiteboardHome.ViewModels;
using ZShoppe.Client.WhiteboardHome.Views;

namespace ZShoppe.Client
{
    public class Bootstrapper : PrismApplication
    {
        private readonly ILogger _logger;

        public Bootstrapper(IPlatformInitializer initializer ):base(initializer)
        {
            _logger = Container.Resolve<ILogger>().ForContext<Bootstrapper>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<INavigationService, PageNavigationService>();            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<WhiteboardServiceModuleDefinition>();
            moduleCatalog.AddModule<WhiteboardViewModelModuleDefinition>();
            moduleCatalog.AddModule<WhiteboardViewModuleDefinition>();
            moduleCatalog.AddModule<CommonServicesModuleDefinition>();
            moduleCatalog.AddModule<DetailsViewModuleDefinition>();
            moduleCatalog.AddModule<DetailsViewModelModuleDefinition>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync("WhiteboardHomePage/NavigationPage/DetailPage");
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ResolveViewModel);
            base.ConfigureViewModelLocator();
        }

        /// <summary>
        /// Convention based ViewModel resolver
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        private Type ResolveViewModel(Type viewType)
        {
            var viewName = viewType.FullName;
            viewName = viewName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelAssemblyName = viewAssemblyName.Replace(".Views", ".ViewModels");
            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewModelAssemblyName);
            Type viewModelType = null;

            try
            {
                viewModelType = Type.GetType(viewModelName, true);
            }
            catch (Exception e)
            {
                //throw;
                //Debugger.Break();
                // _logger.Error(e, $"Unable to resolve ViewModel by the fallowing name:\n {viewModelName}\n");
            }

            return viewModelType;
        }
    }
}
