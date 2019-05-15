using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZShoppe.Client.Common.Contracts.ContentTree.Models
{
    public class AdvertismentTileModel : TileModel
    {
        private IEnumerable<AdvertisementModel> _advertisementModels;

        public IEnumerable<AdvertisementModel> AdvertisementModels
        {
            get => _advertisementModels ?? Enumerable.Empty<AdvertisementModel>().ToArray();
            set => _advertisementModels = value;
        }
    }
}
