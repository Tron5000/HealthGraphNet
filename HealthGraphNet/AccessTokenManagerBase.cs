﻿using System;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

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
        public abstract void InitAccessToken(string code);
        public abstract void InitAccessTokenAsync(Action success, Action<HealthGraphException> failure, string code);

        internal readonly ISerializer DefaultJsonSerializer = new JsonIgnoreNullSerializer();

        #endregion

        #region Fields and Properties

        private const string ApiBaseUrl = "https://api.runkeeper.com";

        private RestClient _client { get; set; }

        #endregion

        #region Constructors

        public AccessTokenManagerBase()
        {
            //Initialize the rest client
            _client = new RestClient();
            _client.ClearHandlers();
            _client.AddHandler("*", new JsonDeserializer());
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
        internal virtual T Execute<T>(IRestRequest request, string baseUrl = null) where T : new()
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
            {
                _client.BaseUrl = baseUrl;
            }
            else
            {
                _client.BaseUrl = ApiBaseUrl;
            }
            IRestResponse<T> response = _client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HealthGraphException(response);
            }
            return response.Data;
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
        internal virtual void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<HealthGraphException> failure, string baseUrl = null) where T : new()
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
        protected void SetAuthenticator()
        {
            if ((Token != null) && (string.IsNullOrEmpty(Token.AccessToken) == false))
            {
                _client.Authenticator = new OAuth2RequestHeaderAuthenticator(Token.TokenType, Token.AccessToken);
            }
        }

        #endregion
    }
}