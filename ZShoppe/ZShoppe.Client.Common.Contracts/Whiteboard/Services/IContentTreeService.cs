using System.Collections.Generic;
using System.Threading.Tasks;
using ZShoppe.Client.Common.Contracts.ContentTree.Models;

namespace ZShoppe.Client.Common.Contracts.Whiteboard.Services
{
    public interface IContentTreeService
    {
        Task<IEnumerable<TileModel>> GetContentTree();
    }
}
