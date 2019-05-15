using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using ZShoppe.Client.Common.Contracts;
using ZShoppe.Client.Common.Contracts.Categories;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;
using ZShoppe.Client.Common.ViewModels;

namespace ZShoppe.Client.WhiteboardHome.ViewModels.Tiles
{
    class AdvertisementTileViewModel : BaseViewModel, IAdvertisementTile
    {
        private readonly IEventAggregator _eventAggregator;

        public ICommand ActivateTileCommand { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<AdvertisementModel> AdvertisementModels { get; set; }
        public string DisplayName { get; set; }
        public string FeatureBackgroundImage { get; set; }
        public string Url { get; set; }

        public AdvertisementTileViewModel(int index, AdvertismentTileModel model, IEventAggregator eventAggregator)
        {
            DisplayName = model.DisplayName;
            FeatureBackgroundImage = model.FeatureBackgroundImage;
            Url = model.Url;
            AdvertisementModels = model.AdvertisementModels;
            _eventAggregator = eventAggregator;
        }
    }
}
