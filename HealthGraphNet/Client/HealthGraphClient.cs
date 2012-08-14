﻿using System;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using System.Threading.Tasks;
using HealthGraphNet.Exceptions;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// The meat of the HealthGraphClient class.  Wrapper sync and async calls to specific areas of functionality are implemented as 
    /// partial classes throughout the Client folder.
    /// Inspiration for this convention of wrapping a rest-based API gleaned from the DropNet project: https://github.com/dkarzon/DropNet
    /// </summary>
    public partial class HealthGraphClient
    {
        #region Fields and Properties

        private const string ApiBaseUrl = "https://api.runkeeper.com";
        private const string AccessTokenUrl = "https://runkeeper.com/apps/token";

        private string _clientId;
        private string _clientSecret;
        private string _requestUri;
        private RestClient _restClient;

        private AccessTokenModel _token;
        public AccessTokenModel Token 
        {
            get 
            {
                return _token;
            }
            set 
            {
                _token = value;
                SetAuthenticator();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Use this constructor when we don't have the access token yet.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="requestUri"></param>
        public HealthGraphClient(string clientId, string clientSecret, string requestUri)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _requestUri = requestUri;

            //Initialize the rest client
            _restClient = new RestClient(ApiBaseUrl);
            _restClient.ClearHandlers();
            _restClient.AddHandler("*", new JsonDeserializer());
        }

        /// <summary>
        /// Use this constructor if the access token has already been determined.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="requestUri"></param>
        /// <param name="accessToken"></param>
        public HealthGraphClient(string clientId, string clientSecret, string requestUri, string accessToken) : this(clientId, clientSecret, requestUri)
        {
            Token = new AccessTokenModel { AccessToken = accessToken };
        }

        #endregion

        #region Token Assignment

        /// <summary>
        /// Initialize the token synchronously based on the auth url code. 
        /// </summary>
        /// <param name="code"></param>
        public void InitAccessToken(string code)
        {
            IRestRequest request = new RestRequest(Method.POST);
            request = AddAccessTokenParams(request, code);
            Token = Execute<AccessTokenModel>(request, AccessTokenUrl);
        }

        /// <summary>
        /// Initialize the token asynchronously based on the auth url code.
        /// </summary>
        /// <param name="code"></param>
        public void InitRequestAccessTokenAsync(string code)
        {
            IRestRequest request = new RestRequest(Method.POST);
            request = AddAccessTokenParams(request, code);
            ExecuteAsync<AccessTokenModel>(request, (token) =>
            {
                Token = token;
            },
            (ex) =>
            {
                throw ex;            
            }, AccessTokenUrl);
        }

        /// <summary>
        /// Populates parameters populates parameters for token request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private IRestRequest AddAccessTokenParams(IRestRequest request, string code)
        {
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", code);
            request.AddParameter("client_id", _clientId);
            request.AddParameter("client_secret", _clientSecret);
            request.AddParameter("redirect_uri", _requestUri);
            return request;
        }

        #endregion

        #region Synchronous IRequest Execution

        /// <summary>
        /// Synchronous request returning data as T.         
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl.
        /// Throws a HealthGraphException if response is anything other than OK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        private T Execute<T>(IRestRequest request, string baseUrl = null) where T : new()
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _restClient.BaseUrl = baseUrl;
            }
            else
            {
                _restClient.BaseUrl = ApiBaseUrl;
            }
            IRestResponse<T> response = _restClient.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HealthGraphException(response);
            }
            return response.Data;
        }

        /// Synchronous request is performed on request.    
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl.
        /// Throws a HealthGraphException if response is anything other than OK.
        private IRestResponse Execute(IRestRequest request, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _restClient.BaseUrl = baseUrl;
            }
            else
            {
                _restClient.BaseUrl = ApiBaseUrl;
            }
            IRestResponse response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HealthGraphException(response);
            }
            return response;
        }

        #endregion

        #region Asynchronous IRequestion Execution

        /// <summary>
        /// If mobile and network not available, stops execution.  Otherwise, async request returning data as T.  
        /// Success is executed if success and failure is executed if status code is not OK.
        /// baseUrl is optional and may be assigned if restClient needs to be anything other than ApiBaseUrl.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        /// <param name="baseUrl"></param>
        private void ExecuteAsync(IRestRequest request, Action<IRestResponse> success, Action<HealthGraphException> failure, string baseUrl = null)
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
                _restClient.BaseUrl = baseUrl;
            }
            else
            {
                _restClient.BaseUrl = ApiBaseUrl;
            }
            _restClient.ExecuteAsync(request, (response, asynchandle) =>
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    failure(new HealthGraphException(response));
                }
                else
                {
                    success(response);
                }
            });
        }

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
        private void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<HealthGraphException> failure, string baseUrl) where T : new()
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
                _restClient.BaseUrl = baseUrl;
            }
            else
            {
                _restClient.BaseUrl = ApiBaseUrl;
            }
            _restClient.ExecuteAsync<T>(request, (response, asynchandle) =>
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    failure(new HealthGraphException(response));
                }
                else
                {
                    success(response.Data);
                }
            });
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Sets the oauth token as a request header - called everytime AccessToken changes. 
        /// </summary>
        private void SetAuthenticator()
        {
            if ((Token != null) && (string.IsNullOrEmpty(Token.AccessToken) == false))
            {
                _restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token.AccessToken);
            }
        }

        #endregion
    }
}