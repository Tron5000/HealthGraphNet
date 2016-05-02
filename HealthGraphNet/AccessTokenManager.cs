﻿using System;
using System.Net;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using HealthGraphNet.Models;
using System.Net.Http;
using System.Threading.Tasks;
using HealthGraphNet.RestSharp;
using RestSharp.Portable.Authenticators.OAuth2.Infrastructure;
using RestSharp.Portable.Authenticators;

namespace HealthGraphNet
{
    /// <summary>
    /// AccessTokenManager handles creation and management of the OAuth access token.
    /// </summary>
    public class AccessTokenManager : AccessTokenManagerBase
    {
        private HealthGraphClient _client;
        private OAuth2RequestHeaderAuthenticator _authenticator;

        public OAuth2Authenticator Authenticator { get; set; }

        #region Fields and Properties

        //protected const string AccessTokenUrl = "https://runkeeper.com/apps/token";
        //protected const string DefaultTokenType = "Bearer";

        //private string _clientId;
        //private string _clientSecret;
        //private string _requestUri;

        //private AccessTokenModel _token;
        //public override AccessTokenModel Token
        //{
        //    get
        //    {
        //        return _token;
        //    }
        //    set
        //    {
        //        _token = value;
        //        //SetAuthenticator();
        //    }
        //}

        #endregion

        #region Constructors

        ///// <summary>
        ///// Use this constructor when we don't have the access token yet.
        ///// </summary>
        ///// <param name="clientId"></param>
        ///// <param name="clientSecret"></param>
        ///// <param name="redirectUri"></param>
        //public AccessTokenManager(string clientId, string clientSecret, string redirectUri)
        //    : base()
        //{
        //    var config = new global::RestSharp.Portable.Authenticators.OAuth2.Configuration.RuntimeClientConfiguration();
        //    config.IsEnabled = false;
        //    config.ClientId = clientId;
        //    config.ClientSecret = clientSecret;
        //    config.RedirectUri = redirectUri;
        //    //config.Scope = scope;
        //    _client = new HealthGraphClient(new RequestFactory(), config);
        //    _authenticator = new OAuth2RequestHeaderAuthenticator(_client);
        //}

        public AccessTokenManager(IAuthenticator authenticator)
        {
            Client.Authenticator = authenticator;
        }

        /// <summary>
        /// Use this constructor if the access token has already been determined.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="redirectUri"></param>
        /// <param name="accessToken"></param>
        //public AccessTokenManager(string clientId, string clientSecret, string redirectUri, string accessToken)
        //    : this(clientId, clientSecret, redirectUri)
        //{
        //    _authenticator.AccessToken = accessToken;
        //    _authenticator.TokenType = DefaultTokenType;
        //    //Token = new AccessTokenModel { AccessToken = accessToken, TokenType = DefaultTokenType };
        //}

        #endregion

        #region Token Assignment

        /// <summary>
        /// Initialize the token synchronously based on the auth url code. 
        /// </summary>
        /// <param name="code"></param>
        //public override async Task InitAccessToken(string code)
        //{
        //    IRestRequest request = new RestRequest(Method.POST);
        //    request = AddAccessTokenParams(request, code);
        //    Token = await Execute<AccessTokenModel>(request, AccessTokenUrl);
        //}

        ///// <summary>
        ///// Populates parameters populates parameters for token request.
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //private IRestRequest AddAccessTokenParams(IRestRequest request, string code)
        //{
        //    request.AddParameter("grant_type", "authorization_code");
        //    request.AddParameter("code", code);
        //    request.AddParameter("client_id", _clientId);
        //    request.AddParameter("client_secret", _clientSecret);
        //    request.AddParameter("redirect_uri", _requestUri);
        //    return request;
        //}

        #endregion
    }
}