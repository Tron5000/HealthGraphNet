using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;

namespace HealthGraphNet
{
    /// <summary>
    /// Passed to each service endpoint class to provide token management.  Used an abstract class instead of an interface
    /// to be able to mix internal and public method signatures (we want to expose the AccessToken to the consumer of this library, 
    /// but hide the IRequest, RestClient and other low level restsharp requests associated with the token.  Because it's an abstract class 
    /// it can still be mocked or stubbed rather easily for testing purposes.
    /// </summary>
    public abstract class AccessTokenManagerBase
    {
        #region Abstract Members

        public abstract AccessTokenModel Token { get; set; }
        public abstract Task InitAccessToken(string code);

        internal readonly ISerializer DefaultJsonSerializer = new JsonNETSerializer();
        private const string LocationHeaderName = "Location";

        #endregion

        #region Fields and Properties

        private const string ApiBaseUrl = "https://api.runkeeper.com";

        protected RestClient Client { get; private set; }

        #endregion

        #region Constructors

        public AccessTokenManagerBase()
        {
            //Initialize the rest client
            Client = new RestClient();
            Client.ClearHandlers();
            Client.AddHandler("*", new JsonNETDeserializer());
        }

        #endregion

        #region IRequest Execution

        /// <summary>
        /// Synchronous request returning data as T.         
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl.
        /// Throws a HealthGraphException if response is anything other than OK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        internal virtual async Task<T> Execute<T>(IRestRequest request, string baseUrl = null, HttpStatusCode? expectedStatusCode = null) where T : new()
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                Client.BaseUrl = new Uri(baseUrl);
            }
            else
            {
                Client.BaseUrl = new Uri(ApiBaseUrl);
            }
            IRestResponse<T> response = await Client.Execute<T>(request);
            //If a particular status code is expected, check for it, otherwise assume we are looking for an OK
            HttpStatusCode codeToCheckAgainst = expectedStatusCode.HasValue ? expectedStatusCode.Value : HttpStatusCode.OK;
            if (response.StatusCode != codeToCheckAgainst)
            {
                throw new HealthGraphException(response);
            }
            return response.Data;
        }

        /// <summary>
        /// Synchronous request.  baseUrl is optional and may be assigned if restClient eneds to be anything other than ApiBaseUrl.
        /// Throws a HealthGraphException if response is anything other than OK.
        /// No data is returned.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="baseUrl"></param>
        internal virtual async Task Execute(IRestRequest request, string baseUrl = null, HttpStatusCode? expectedStatusCode = null)
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                Client.BaseUrl = new Uri(baseUrl);
            }
            else
            {
                Client.BaseUrl = new Uri(ApiBaseUrl);
            }
            IRestResponse response = await Client.Execute(request);
            //If a particular status code is expected, check for it, otherwise assume we are looking for an OK
            HttpStatusCode codeToCheckAgainst = expectedStatusCode.HasValue ? expectedStatusCode.Value : HttpStatusCode.OK;
            if (response.StatusCode != codeToCheckAgainst)
            {
                throw new HealthGraphException(response);
            }
        }

        /// <summary>
        /// Synchronous request for creation of a resource.  Returns the Location header if present, otherwise returns null.
        /// Throws a HealthGraphException if response is anything other than CREATED.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headerNameOfInterest"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        internal virtual async Task<string> ExecuteCreate(IRestRequest request, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                Client.BaseUrl = new Uri(baseUrl);
            }
            else
            {
                Client.BaseUrl = new Uri(ApiBaseUrl);
            }
            IRestResponse response = await Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new HealthGraphException(response);
            }
            IEnumerable<string> locationHeaderValues = null;
            if (response.Headers.TryGetValues(LocationHeaderName, out locationHeaderValues))
            {
                return locationHeaderValues.First();
            }
            
            return null;
        }

        /*
        /// <summary>
        /// If mobile and network not available, stops execution.  Otherwise, async request is performed on request.  
        /// Success is executed if success and failure is executed if status code is not OK.
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        /// <param name="baseUrl"></param>
        internal virtual void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<HealthGraphException> failure, string baseUrl = null, HttpStatusCode? expectedStatusCode = null) where T : new()
        {
#if MONOTOUCH
            //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new HealthGraphException { StatusCode = System.Net.HttpStatusCode.BadGateway });
                return;
            }
#endif

            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _client.BaseUrl = baseUrl;
            }
            else
            {
                _client.BaseUrl = ApiBaseUrl;
            }
            _client.ExecuteAsync<T>(request, (response, asynchandle) =>
            {
                //If a particular status code is expected, check for it, otherwise assume we are looking for an OK
                HttpStatusCode codeToCheckAgainst = expectedStatusCode.HasValue ? expectedStatusCode.Value : HttpStatusCode.OK;
                if (response.StatusCode != codeToCheckAgainst)
                {
                    failure(new HealthGraphException(response));
                }
                else
                {
                    success(response.Data);
                }
            });
        }

        /// <summary>
        /// If mobile and network not available, stops execution.  Otherwise, async request is performed on request.  
        /// Success is executed if success and failure is executed if status code is not OK.
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl. 
        /// No data is returned.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        /// <param name="baseUrl"></param>
        internal virtual void ExecuteAsync(IRestRequest request, Action success, Action<HealthGraphException> failure, string baseUrl = null, HttpStatusCode? expectedStatusCode = null)
        {
#if MONOTOUCH
            //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new HealthGraphException { StatusCode = System.Net.HttpStatusCode.BadGateway });
                return;
            }
#endif

            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _client.BaseUrl = baseUrl;
            }
            else
            {
                _client.BaseUrl = ApiBaseUrl;
            }
            _client.ExecuteAsync(request, (response, asynchandle) =>
            {
                //If a particular status code is expected, check for it, otherwise assume we are looking for an OK
                HttpStatusCode codeToCheckAgainst = expectedStatusCode.HasValue ? expectedStatusCode.Value : HttpStatusCode.OK;
                if (response.StatusCode != codeToCheckAgainst)
                {
                    failure(new HealthGraphException(response));
                }
                else
                {
                    success();
                }
            });
        }

        /// <summary>
        /// If mobile and network not available, stops execution.  Otherwise, performs an asynchronous creation of a resource.  
        /// Passes the Location header to Success if present, otherwise passes null.
        /// Failure is executed if response is anything other than CREATED.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headerNameOfInterest"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        internal virtual void ExecuteCreateAsync(IRestRequest request, Action<string> success, Action<HealthGraphException> failure, string baseUrl = null)
        {
#if MONOTOUCH
            //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new HealthGraphException { StatusCode = System.Net.HttpStatusCode.BadGateway });
                return;
            }
#endif

            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _client.BaseUrl = baseUrl;
            }
            else
            {
                _client.BaseUrl = ApiBaseUrl;
            }
            _client.ExecuteAsync(request, (response, asynchandle) =>
            {
                if (response.StatusCode != HttpStatusCode.Created)
                {
                    failure(new HealthGraphException(response));
                }
                else
                {
                    string locationHeaderValue = null;
                    var locationHeader = response.Headers.Where(h => h.Name == LocationHeaderName).FirstOrDefault();
                    if (locationHeader != null)
                    {
                        locationHeaderValue = locationHeader.Value as string;
                    }
                    success(locationHeaderValue);
                }
            });
        }*/

        #endregion

        #region Helper Methods

        /// <summary>
        /// Sets the oauth token as a request header - called everytime AccessToken changes. 
        /// </summary>
        //protected void SetAuthenticator()
        //{
        //    if ((Token != null) && (string.IsNullOrEmpty(Token.AccessToken) == false))
        //    {
        //        var config = new HealthGraphClient();
        //        _client.Authenticator = new OAuth2RequestHeaderAuthenticator(config);//Token.TokenType, Token.AccessToken);
        //    }
        //}

        #endregion
    }
}