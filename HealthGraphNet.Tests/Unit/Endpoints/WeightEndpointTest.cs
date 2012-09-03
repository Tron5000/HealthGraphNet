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

        [Test()]
        public void GetWeight_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.GetWeight(validPath); });
        }

        [Test()]
        public void GetWeight_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.GetWeight("Not validPath."); });
        }

        [Test()]
        public void GetWeightAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.GetWeightAsync((m) => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void GetWeightAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.GetWeightAsync((m) => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void DeleteWeight_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.DeleteWeight(validPath); });
        }

        [Test()]
        public void DeleteWeight_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.DeleteWeight("Not validPath."); });
        }

        [Test()]
        public void DeleteWeightAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.DeleteWeightAsync(() => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void DeleteWeightAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel { Weight = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.DeleteWeightAsync(() => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void UpdateWeight_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.UpdateWeight(ValidWeight); });
        }

        [Test()]
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
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.UpdateWeight(ValidWeight); });
        }

        [Test()]
        public void CreateWeight_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            WeightEndpoint weightRequest = new WeightEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { weightRequest.CreateWeight(ValidWeightNew); });
        }

        [Test()]
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
            Assert.Throws(typeof(ArgumentException), () => { weightRequest.CreateWeight(ValidWeightNew); });
        }

        #endregion
    }
}