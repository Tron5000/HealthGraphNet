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
    public class ProfileEndpointTest
    {
        #region Tests

        [Test]
        public void UpdateProfile_AthleteTypeNotValid_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            ProfileEndpoint profileRequest = new ProfileEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await profileRequest.UpdateProfile("This is not a valid Athlete Type."); });
        }

        [Test]
        public void UpdateProfile_AthleteTypeValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            ProfileEndpoint profileRequest = new ProfileEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await profileRequest.UpdateProfile(ProfileEndpoint.ValidAthleteType.First()); });
        }

        #endregion
    }
}