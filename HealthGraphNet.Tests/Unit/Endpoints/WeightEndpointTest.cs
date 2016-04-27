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
    public class WeightEndpointTest
    {
        #region Fields, Properties and Setup

        protected WeightPastModel ValidWeight { get; set; }

        protected WeightNewModel ValidWeightNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidWeight = new WeightPastModel
            {
                Weight = 10
            };

            ValidWeightNew = new WeightNewModel
            {
                Timestamp = DateTime.Now,
                Weight = 10,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion

        #region Tests

        [Test]
        public void GetWeight_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await weightRequest.GetWeight(validPath); });
        }

        [Test]
        public void GetWeight_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await weightRequest.GetWeight("Not validPath."); });
        }

        [Test]
        public void DeleteWeight_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await weightRequest.DeleteWeight(validPath); });
        }

        [Test]
        public void DeleteWeight_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await weightRequest.DeleteWeight("Not validPath."); });
        }

        [Test]
        public void UpdateWeight_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await weightRequest.UpdateWeight(ValidWeight); });
        }

        [Test]
        public void UpdateWeight_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidWeight.Bmi = null;
            ValidWeight.FatPercent = null;
            ValidWeight.FreeMass = null;
            ValidWeight.MassWeight = null;
            ValidWeight.Weight = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await weightRequest.UpdateWeight(ValidWeight); });
        }

        [Test]
        public void CreateWeight_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await weightRequest.CreateWeight(ValidWeightNew); });
        }

        [Test]
        public void CreateWeight_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidWeightNew.Bmi = null;
            ValidWeightNew.FatPercent = null;
            ValidWeightNew.FreeMass = null;
            ValidWeightNew.MassWeight = null;
            ValidWeightNew.Weight = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await weightRequest.CreateWeight(ValidWeightNew); });
        }

        #endregion
    }
}