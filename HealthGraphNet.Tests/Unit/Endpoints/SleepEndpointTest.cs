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
    public class SleepEndpointTest
    {
        #region Fields, Properties and Setup

        protected SleepPastModel ValidSleep { get; set; }

        protected SleepNewModel ValidSleepNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidSleep = new SleepPastModel
            {
                TotalSleep = 60
            };

            ValidSleepNew = new SleepNewModel
            {
                Timestamp = DateTime.Now,
                TotalSleep = 60,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion

        #region Tests

        [Test]
        public void GetSleep_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await sleepRequest.GetSleep(validPath); });
        }

        [Test]
        public void GetSleep_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await sleepRequest.GetSleep("Not validPath."); });
        }

        [Test]
        public void DeleteSleep_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await sleepRequest.DeleteSleep(validPath); });
        }

        [Test]
        public void DeleteSleep_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await sleepRequest.DeleteSleep("Not validPath."); });
        }

        [Test]
        public void UpdateSleep_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await sleepRequest.UpdateSleep(ValidSleep); });
        }

        [Test]
        public void UpdateSleep_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidSleep.Awake = null;
            ValidSleep.Deep = null;
            ValidSleep.Light = null;
            ValidSleep.Rem = null;
            ValidSleep.TimesWoken = null;
            ValidSleep.TotalSleep = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await sleepRequest.UpdateSleep(ValidSleep); });
        }

        [Test]
        public void CreateSleep_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await sleepRequest.CreateSleep(ValidSleepNew); });
        }

        [Test]
        public void CreateSleep_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidSleepNew.Awake = null;
            ValidSleepNew.Deep = null;
            ValidSleepNew.Light = null;
            ValidSleepNew.Rem = null;
            ValidSleepNew.TimesWoken = null;
            ValidSleepNew.TotalSleep = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await sleepRequest.CreateSleep(ValidSleepNew); });
        }

        #endregion
    }
}