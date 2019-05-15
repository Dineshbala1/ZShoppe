using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ZShoppe.Client.Common.Contracts
{
    public interface ITileProvider
    {
        ICommand ActivateTileCommand { get; set; }
    }

    public interface IProductTile : ITileProvider
    {
        bool Enabled { get; set; }

        ICommand ProductTapcommand { get; }
    }

    public interface ICategoryTile : ITileProvider
    {
        bool Enabled { get; set; }

        ICommand NavigateToCategoryDetailsCommand { get;}
    }

    public interface IAdvertisementTile : ITileProvider
    {
        bool Enabled { get; set; }
    }
}
