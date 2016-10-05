using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HealthGraphNet;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Configuration;
using HealthGraphNet.Tests.Unit.RestSharp;

namespace HealthGraphNet.Tests.Integration
{
    [TestFixture]
    public abstract class ClientSetupBase
    {
        #region Fields, Properties and Setup.

        protected string AccessToken
        {
            get
            {
                return ConfigurationManager.AppSettings["AccessToken"];
            }
        }

        public Client TokenManager { get; set; }

        /// <summary>
        /// Prior to any other setup make sure that ClientId, ClientSecret, RequestUri and AccessToken have been defined.
        /// If so, create and initialize the token manager so it will be ready to be used in subclasses.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                throw new ArgumentException("In order to run integration tests, AccessToken in the app.config file!");
            }

            var authenticator = new StaticAuthenticator() { AccessToken = AccessToken };
            TokenManager = new Client(authenticator);
        }

        #endregion
    }
}