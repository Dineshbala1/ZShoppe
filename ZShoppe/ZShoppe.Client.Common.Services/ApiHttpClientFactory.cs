using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ZShoppe.Client.Common.Contracts;

namespace ZShoppe.Client.Common.Services
{
    public class ApiHttpClientFactory : IApiHttpClientFactory
    {
        private readonly object _configuration;

        private HttpClient _sharedClient;

        public ApiHttpClientFactory()
        {
            
        }

        public HttpClient GetClient()
        {
            if (_sharedClient == null)
            {
                return _sharedClient = BuildClient(true);
            }

            var currentBaseUri = GetBaseUri();

            if (currentBaseUri != null && currentBaseUri != _sharedClient.BaseAddress)
            {
                _sharedClient.BaseAddress = currentBaseUri;
            }

            return _sharedClient;
        }

        private HttpClient BuildClient(bool addHeaders)
        {
            var httpClientHandler = new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic };
            var client = new HttpClient(httpClientHandler)
            {
                BaseAddress = GetBaseUri()
            };

            if (!addHeaders)
            {
                return client;
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private Uri GetBaseUri()
        {
            var baseUrl = "http://dev-api.velchekku.com/api/";//_configuration.ApiGatewayBaseAddress;
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            return new Uri(baseUrl);
        }

        private void SetHeader<T>(string headerName, T value)
        {
            if (_sharedClient == null)
            {
                _sharedClient = BuildClient(true);
            }

            RemoveExistingHeader(headerName);

            _sharedClient.DefaultRequestHeaders.Add(headerName, value.ToString());
        }

        private void RemoveExistingHeader(string headerName)
        {
            if (_sharedClient.DefaultRequestHeaders.Contains(headerName))
            {
                _sharedClient.DefaultRequestHeaders.Remove(headerName);
            }
        }
    }
}
