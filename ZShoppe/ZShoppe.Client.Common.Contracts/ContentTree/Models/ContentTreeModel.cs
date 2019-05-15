using System;
using System.Collections.Generic;
using System.Text;

namespace ZShoppe.Client.Common.Contracts.ContentTree.Models
{
    public class ContentTreeModel
    {
        public IEnumerable<TileModel> Tiles { get; set; }
    }
}
