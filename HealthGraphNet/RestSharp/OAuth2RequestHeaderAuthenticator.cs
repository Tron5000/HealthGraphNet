using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// Used as a replacement for OAuth2AuthorizationRequestHeaderAuthenticator (https://github.com/restsharp/RestSharp/blob/master/RestSharp/Authenticators/OAuth2Authenticator.cs).
    /// Because HealthGraph uses the tokenType instead of the literal "OAuth" as the first part of the _authorizationValue.
    /// </summary>
    internal class OAuth2RequestHeaderAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Stores the Authoriztion header value as "OAuth accessToken". used for performance.
        /// </summary>
        private readonly string _authorizationValue;

        public OAuth2RequestHeaderAuthenticator(string tokenType, string accessToken) : base(accessToken)
        {
            // Conatenate during constructor so that it is only done once. can improve performance.
            _authorizationValue = tokenType + " " + accessToken;
        }

        public override void Authenticate(IRestClient client, IRestRequest request)
        {
            // only add the Authorization parameter if it hasn't been added.
            if (!request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddParameter("Authorization", _authorizationValue, ParameterType.HttpHeader);
            }
        }
    }
}