using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharp;
using Moq;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Tests.Unit.RestSharp
{
    [TestFixture()]
    public class OAuth2RequestHeaderAuthenticatorTest
    {
        #region Tests

        [Test()]
        public void Authenticate_EmptyParameterRequest_AddsAccessTokenAsHeaderParameter()
        {
            //Arrange
            var addAuthParameter = false;
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            var AccessToken = "ABCDEFGHIJ";
            var AccessTokenType = "Bearer";            
            Mock<IRestRequest> restRequest = new Mock<IRestRequest>();
            restRequest.Setup(r => r.Parameters).Returns(new List<Parameter>());
            restRequest.Setup(r => r.AddParameter("Authorization", AccessTokenType + " " + AccessToken, ParameterType.HttpHeader)).Callback(() => addAuthParameter = true);
            //Act
            var authenticator = new OAuth2RequestHeaderAuthenticator(AccessTokenType, AccessToken);
            authenticator.Authenticate(restClient.Object, restRequest.Object);
            //Assert
            Assert.IsTrue(addAuthParameter);
        }

        [Test()]
        public void Authenticate_AuthParameterAlreadyPresent_DoesNotAddAccessTokenAsHeaderParameter()
        {
            //Arrange
            var addAuthParameter = false;
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            var AccessToken = "ABCDEFGHIJ";
            var AccessTokenType = "Bearer";
            Mock<IRestRequest> restRequest = new Mock<IRestRequest>();
            restRequest.Setup(r => r.Parameters).Returns(new List<Parameter> { new Parameter { Name = "Authorization" }});
            restRequest.Setup(r => r.AddParameter("Authorization", AccessTokenType + " " + AccessToken, ParameterType.HttpHeader)).Callback(() => addAuthParameter = true);
            //Act
            var authenticator = new OAuth2RequestHeaderAuthenticator(AccessTokenType, AccessToken);
            authenticator.Authenticate(restClient.Object, restRequest.Object);
            //Assert
            Assert.IsFalse(addAuthParameter);
        }

        #endregion
    }
}