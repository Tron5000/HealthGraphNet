using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Tests.Unit
{
    [TestFixture()]
    public class StreetTeamEndpointTest
    {
        #region Tests

        [Test()]
        public void GetStreetTeam_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            StreetTeamEndpoint streetTeamRequest = new StreetTeamEndpoint(tokenManager.Object, new UsersModel { Team = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { streetTeamRequest.GetStreetTeam(validPath); });
        }

        [Test()]
        public void GetStreetTeam_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            StreetTeamEndpoint streetTeamRequest = new StreetTeamEndpoint(tokenManager.Object, new UsersModel { Team = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { streetTeamRequest.GetStreetTeam("Not validPath."); });
        }

        [Test()]
        public void GetStreetTeamAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            StreetTeamEndpoint streetTeamRequest = new StreetTeamEndpoint(tokenManager.Object, new UsersModel { Team = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { streetTeamRequest.GetStreetTeamAsync((m) => {}, (ex) => {}, validPath); });
        }

        [Test()]
        public void GetStreetTeamAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            StreetTeamEndpoint streetTeamRequest = new StreetTeamEndpoint(tokenManager.Object, new UsersModel { Team = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { streetTeamRequest.GetStreetTeamAsync((m) => { }, (ex) => { }, "Not validPath."); });
        }

        #endregion
    }
}