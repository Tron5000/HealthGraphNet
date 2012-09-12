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

        [Test()]
        public void GetSleep_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.GetSleep(validPath); });
        }

        [Test()]
        public void GetSleep_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.GetSleep("Not validPath."); });
        }

        [Test()]
        public void GetSleepAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.GetSleepAsync((m) => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void GetSleepAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.GetSleepAsync((m) => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void DeleteSleep_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.DeleteSleep(validPath); });
        }

        [Test()]
        public void DeleteSleep_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.DeleteSleep("Not validPath."); });
        }

        [Test()]
        public void DeleteSleepAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.DeleteSleepAsync(() => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void DeleteSleepAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel { Sleep = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.DeleteSleepAsync(() => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void UpdateSleep_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.UpdateSleep(ValidSleep); });
        }

        [Test()]
        public void UpdateSleep_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidSleep.Awake = null;
            ValidSleep.Deep = null;
            ValidSleep.Light = null;
            ValidSleep.Rem = null;
            ValidSleep.TimesWoken = null;
            ValidSleep.TotalSleep = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.UpdateSleep(ValidSleep); });
        }

        [Test()]
        public void CreateSleep_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { sleepRequest.CreateSleep(ValidSleepNew); });
        }

        [Test()]
        public void CreateSleep_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            SleepEndpoint sleepRequest = new SleepEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidSleepNew.Awake = null;
            ValidSleepNew.Deep = null;
            ValidSleepNew.Light = null;
            ValidSleepNew.Rem = null;
            ValidSleepNew.TimesWoken = null;
            ValidSleepNew.TotalSleep = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { sleepRequest.CreateSleep(ValidSleepNew); });
        }

        #endregion
    }
}