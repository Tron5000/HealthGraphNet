using RestSharp.Portable.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp.Portable;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using HealthGraphNet.RestSharp;
using RestSharp.Portable.Authenticators.OAuth2.Infrastructure;

namespace HealthGraphNet.Samples.Web
{
    /// <summary>
    /// Authenticator for web based apps
    /// </summary>
    public class WebAuthenticator : StaticAuthenticator
    {
        private HealthGraphClient _client;
        public HealthGraphClient Client
        {
            get
            {
                return _client;
            }
        }

        public WebAuthenticator(HealthGraphClient client)
        {
            _client = client;
        }

        public async Task<bool> OnPageLoaded(Uri uri)
        {
            try {
                if (uri.AbsoluteUri.StartsWith(_client.Configuration.RedirectUri))
                {
                    Debug.WriteLine("Navigated to redirect url.");
                    if (uri.Query.IsEmpty())
                        return false;

                    var parameters = uri.Query.Remove(0, 1).ParseQueryString(); // query portion of the response
                    await _client.GetUserInfo(parameters);

                    if (!string.IsNullOrEmpty(_client.AccessToken))
                    {
                        AccessToken = _client.AccessToken;
                        //if (AccessTokenReceived != null)
                        //    AccessTokenReceived(this, new TokenReceivedEventArgs(AccessToken));

                        // dismiss login page
                        //Platform.Current.UserInterface.NavigationService.GoBack();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}