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
    public class BackgroundActivitiesEndpointTest
    {
        #region Fields, Properties and Setup

        protected BackgroundActivitiesPastModel ValidActivity { get; set; }

        protected BackgroundActivitiesNewModel ValidActivityNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidActivity = new BackgroundActivitiesPastModel
            {
                Steps = 500
            };

            ValidActivityNew = new BackgroundActivitiesNewModel
            {
                Timestamp = DateTime.Now,
                Steps = 500,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion

        #region Tests

        [Test]
        public void GetActivity_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel { BackgroundActivities = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activityRequest.GetActivity(validPath); });
        }

        [Test]
        public void GetActivity_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel { BackgroundActivities = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activityRequest.GetActivity("Not validPath."); });
        }

        [Test]
        public void DeleteActivity_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel { BackgroundActivities = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async() => { await activityRequest.DeleteActivity(validPath); });
        }

        [Test]
        public void DeleteActivity_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel { BackgroundActivities = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activityRequest.DeleteActivity("Not validPath."); });
        }


        [Test]
        public void UpdateActivity_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activityRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.CaloriesBurned = null;
            ValidActivity.Steps = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activityRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void CreateActivity_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activityRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            BackgroundActivitiesEndpoint activityRequest = new BackgroundActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.CaloriesBurned = null;
            ValidActivityNew.Steps = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activityRequest.CreateActivity(ValidActivityNew); });
        }

        #endregion
    }
}