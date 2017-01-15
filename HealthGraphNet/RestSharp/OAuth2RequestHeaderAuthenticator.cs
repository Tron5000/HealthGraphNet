using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.OAuth2;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// Used as a replacement for OAuth2AuthorizationRequestHeaderAuthenticator (https://github.com/restsharp/RestSharp/blob/master/RestSharp/Authenticators/OAuth2Authenticator.cs).
    /// Because HealthGraph uses the tokenType instead of the literal "OAuth" as the first part of the _authorizationValue.
    /// </summary>
    internal class OAuth2RequestHeaderAuthenticator : OAuth2Authenticator
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }

        public OAuth2RequestHeaderAuthenticator(HealthGraphClient client) : base(client)
        {
        }

        public override bool CanPreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            return true;
        }

        public override bool CanPreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            return false;
        }

        public override Task PreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            return Task.Run(() =>
            {
                // only add the Authorization parameter if it hasn't been added.
                if (!request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                {
                    request.AddParameter("Authorization", string.Format("{0} {1}", TokenType, AccessToken), ParameterType.HttpHeader);
                }
            });
        }

        public override Task PreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            throw new NotImplementedException();
        }
    }
}