using RestSharp.Portable.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Portable;
using System.Net;
using System.Threading.Tasks;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Samples.MonoTouch
{
    class WebViewAuthenticator : OAuth2Authenticator
    {
        private HealthGraphClient _client;
        public HealthGraphClient Client
        {
            get
            {
                return _client;
            }
        }

        public WebViewAuthenticator(HealthGraphClient client) : base(client)
        {
            _client = client;
        }

        public override bool CanPreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public override bool CanPreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public override Task PreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public override Task PreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            throw new NotImplementedException();
        }
    }
}
