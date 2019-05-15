using System.Reflection;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Navigation
{
    public static class NavigationExtensions
    {
        ///// <summary>
        ///// Registers a Page for navigation.
        ///// </summary>
        ///// <typeparam name="TView">The Type of Page to register</typeparam>
        ///// <param name="builder"><see cref="ContainerBuilder"/> used to register type for Navigation.</param>
        ///// <param name="name">The unique name to register with the Page</param>
        ///// <param name="registerAsSingleton">Registers the type as a singleton.</param>
        //public static void RegisterTypeForNavigation<TView>(this ContainerBuilder builder, IContainerRegistry containerRegistry,string name = null, bool registerAsSingleton = false) where TView : Page
        //{
        //    var viewType = typeof(TView);

        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        name = viewType.Name;
        //    }

        //    if (registerAsSingleton)
        //    {
        //        builder.RegisterType(viewType).Named<Page>(name).SingleInstance();
        //    }
        //    else
        //    {
        //        builder.RegisterType(viewType).Named<Page>(name);
        //    }

        //    containerRegistry.RegisterForNavigation(viewType, name);
        //    PageNavigationRegistry.Register(name, viewType);
        //}

        ///// <summary>
        ///// Registers a Page and it's ViewModel for navigation.
        ///// Note.: If the <typeparam name="TViewModel"/> is an interface then it must be registered to the <see cref="IContainer"/> externally.
        ///// </summary>
        ///// <typeparam name="TView">The Type of Page to register</typeparam>
        ///// <typeparam name="TViewModel">The Type of ViewModel to register</typeparam>
        ///// <param name="builder"><see cref="ContainerBuilder"/> used to register type for Navigation.</param>
        ///// <param name="name">The unique name to register with the Page</param>
        ///// <param name="registerAsSingleton">Registers the type as a singleton.</param>
        //public static void RegisterTypeForNavigation<TView, TViewModel>(this ContainerBuilder builder, string name = null,
        //    bool registerAsSingleton = false) where TView : Page where TViewModel : class
        //{
        //    RegisterTypeForNavigation<TView>(builder,null, name, registerAsSingleton);

        //    if (!typeof(TViewModel).GetTypeInfo().IsInterface)
        //    {
        //        builder.RegisterType<TViewModel>();
        //    }

        //    ViewModelLocationProvider.Register<TView, TViewModel>();
        //}
    }
}
