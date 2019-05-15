using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ZShoppe.Client.Common.Contracts
{
    public interface IApiHttpClientFactory
    {
        HttpClient GetClient();
    }
}
