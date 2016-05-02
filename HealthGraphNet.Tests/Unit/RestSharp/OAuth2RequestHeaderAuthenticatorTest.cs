using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharp.Portable;
using Moq;
using HealthGraphNet.RestSharp;
using System.Threading.Tasks;

namespace HealthGraphNet.Tests.Unit.RestSharp
{
    [TestFixture()]
    public class OAuth2RequestHeaderAuthenticatorTest
    {
        #region Tests

        private HealthGraphClient CreateClient()
        {
            return new HealthGraphClient(new RequestFactory(), null);
        }

        [Test]

        public async Task Authenticate_EmptyParameterRequest_AddsAccessTokenAsHeaderParameter()
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
            var authenticator = new OAuth2RequestHeaderAuthenticator(CreateClient());// AccessTokenType, AccessToken);
            await authenticator.PreAuthenticate(restClient.Object, restRequest.Object, null);
            //Assert
            Assert.IsTrue(addAuthParameter);
        }

        [Test]
        public async Task Authenticate_AuthParameterAlreadyPresent_DoesNotAddAccessTokenAsHeaderParameter()
        {
            //Arrange
            var addAuthParameter = false;
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            var AccessToken = "ABCDEFGHIJ";
            var AccessTokenType = "Bearer";
            Mock<IRestRequest> restRequest = new Mock<IRestRequest>();
            restRequest.Setup(r => r.Parameters).Returns(new List<Parameter> { new Parameter { Name = "Authorization" } });
            restRequest.Setup(r => r.AddParameter("Authorization", AccessTokenType + " " + AccessToken, ParameterType.HttpHeader)).Callback(() => addAuthParameter = true);
            //Act
            var authenticator = new OAuth2RequestHeaderAuthenticator(CreateClient());// AccessTokenType, AccessToken);
            await authenticator.PreAuthenticate(restClient.Object, restRequest.Object, null);
            //Assert
            Assert.IsFalse(addAuthParameter);
        }

        #endregion
    }
}