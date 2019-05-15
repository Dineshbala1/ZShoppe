using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZShoppe.Client.Common.Contracts
{
    public interface IBannerService
    {
        Task<IEnumerable<object>> GetBannersasync();
    }
}
