using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Tests.Integration
{
    [TestFixture()]
    public abstract class AccessTokenManagerSetupBase
    {
        #region Fields, Properties and Setup.

        // In order to run integration tests, ClientId, ClientSecret, RequestUri and AccessToken of your app must be provided.
        // In order to create an application, go to the HealthGraph Applications Portal: http://runkeeper.com/partner/applications
        protected const string ClientId = "";
        protected const string ClientSecret = "";
        protected const string RequestUri = "";
        protected const string AccessToken = "";

        public AccessTokenManager TokenManager { get; set; }

        /// <summary>
        /// Prior to any other setup make sure that ClientId, ClientSecret, RequestUri and AccessToken have been defined.
        /// If so, create and initialize the token manager so it will be ready to be used in subclasses.
        /// </summary>
        [TestFixtureSetUp()]
        public void Init()
        {
            if ((string.IsNullOrEmpty(ClientId)) || (string.IsNullOrEmpty(ClientSecret)) || (string.IsNullOrEmpty(RequestUri)) || (string.IsNullOrEmpty(AccessToken)))
            {
                throw new ArgumentException("In order to run integration tests, please define ClientId, ClientSecret, RequestUri and AccessToken constants in AccessTokenManagerSetupBase.");
            }
            TokenManager = new AccessTokenManager(ClientId, ClientSecret, RequestUri, AccessToken);
        }

        #endregion
    }
}