﻿using System;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// AccessTokenManager handles creation and management of the OAuth access token.
    /// </summary>
    public class AccessTokenManager : AccessTokenManagerBase
    {
        #region Fields and Properties

        protected const string AccessTokenUrl = "https://runkeeper.com/apps/token";
        protected const string DefaultTokenType = "Bearer";

        private string _clientId;
        private string _clientSecret;
        private string _requestUri;

        private AccessTokenModel _token;
        public override AccessTokenModel Token 
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
        public AccessTokenManager(string clientId, string clientSecret, string requestUri) : base()
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _requestUri = requestUri;
        }

        /// <summary>
        /// Use this constructor if the access token has already been determined.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="requestUri"></param>
        /// <param name="accessToken"></param>
        public AccessTokenManager(string clientId, string clientSecret, string requestUri, string accessToken) : this(clientId, clientSecret, requestUri)
        {
            Token = new AccessTokenModel { AccessToken = accessToken, TokenType = DefaultTokenType };
        }

        #endregion

        #region Token Assignment

        /// <summary>
        /// Initialize the token synchronously based on the auth url code. 
        /// </summary>
        /// <param name="code"></param>
        public override void InitAccessToken(string code)
        {
            IRestRequest request = new RestRequest(Method.POST);
            request = AddAccessTokenParams(request, code);
            Token = Execute<AccessTokenModel>(request, AccessTokenUrl);
        }

        /// <summary>
        /// Initialize the token asynchronously based on the auth url code.
        /// </summary>
        /// <param name="code"></param>
        public override void InitAccessTokenAsync(Action success, Action<HealthGraphException> failure, string code)
        {
            IRestRequest request = new RestRequest(Method.POST);
            request = AddAccessTokenParams(request, code);
            ExecuteAsync<AccessTokenModel>(request, (token) =>
            {
                Token = token;
                success();
            },
            (ex) =>
            {
                failure(ex);            
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
    }
}