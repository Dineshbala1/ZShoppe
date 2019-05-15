using System;
using System.Collections.Generic;
using System.Text;

namespace ZShoppe.Client.Common.Contracts
{
    public interface IMasterPresentedUpdateService
    {
        bool IsPresented { get; set; }
    }
}
