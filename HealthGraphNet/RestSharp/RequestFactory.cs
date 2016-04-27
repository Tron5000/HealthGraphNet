using RestSharp.Portable.Authenticators.OAuth2.Infrastructure;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace HealthGraphNet.RestSharp
{
    public class RequestFactory : IRequestFactory
    {
        #region IRequestFactory implementation

        public IRestClient CreateClient()
        {
            return new RestClient();
        }

        public IRestRequest CreateRequest(string resource)
        {
            return new RestRequest(resource);
        }

        #endregion
    }
}

