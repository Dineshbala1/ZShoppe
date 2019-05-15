using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.WhiteboardHome.ViewModels.Tiles;

namespace ZShoppe.Client.WhiteboardHome.ViewModels
{
    public class WhiteboardViewModelModuleDefinition : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(ITileProvider),typeof(ProductTileViewModel), nameof(ProductTileModel));
            containerRegistry.Register(typeof(ITileProvider), typeof(CategoryTileViewModel), nameof(CategoryTileModel));
            containerRegistry.Register(typeof(ITileProvider), typeof(AdvertisementTileViewModel), nameof(AdvertismentTileModel));

            containerRegistry.Register<WhiteboardHomePageViewModel>();
            containerRegistry.Register<DetailPageViewModel>();
            containerRegistry.Register<MasterPageViewModel>();

        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();

            containerProvider.GetContainer().RegisterType<Func<int, TileModel, ITileProvider>>(new InjectionFactory(FactoryFunc));
        }

        private Func<int, TileModel, ITileProvider> FactoryFunc(IUnityContainer unityContainer, Type types, string arg3)
        {
            return ((index, targetModel) =>
            {
                var type = targetModel.GetType();
                return unityContainer.Resolve<ITileProvider>(type.Name, new ParameterOverride("index", index),
                    new ParameterOverride("model", targetModel));
            });
        }
    }
}
