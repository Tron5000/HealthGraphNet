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
    public class DiabetesMeasurementsEndpointTest
    {
        #region Fields, Properties and Setup

        protected DiabetesMeasurementsPastModel ValidMeasurement { get; set; }

        protected DiabetesMeasurementsNewModel ValidMeasurementNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidMeasurement = new DiabetesMeasurementsPastModel
            {
                Insulin = 100
            };

            ValidMeasurementNew = new DiabetesMeasurementsNewModel
            {
                Timestamp = DateTime.Now,
                Insulin = 10,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion    
        
        #region Tests

        [Test]
        public void GetMeasurement_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel { Diabetes = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await measurementRequest.GetMeasurement(validPath); });
        }

        [Test]
        public void GetMeasurement_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel { Diabetes = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await measurementRequest.GetMeasurement("Not validPath."); });
        }

        [Test]
        public void DeleteMeasurement_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel { Diabetes = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async() => { await measurementRequest.DeleteMeasurement(validPath); });
        }

        [Test]
        public void DeleteMeasurement_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel { Diabetes = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await measurementRequest.DeleteMeasurement("Not validPath."); });
        }

        [Test]
        public void UpdateMeasurement_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await measurementRequest.UpdateMeasurement(ValidMeasurement); });
        }

        [Test]
        public void UpdateMeasurement_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidMeasurement.CPeptide = null;
            ValidMeasurement.FastingPlasmaGlucoseTest = null;
            ValidMeasurement.HemoglobinA1c = null;
            ValidMeasurement.Insulin = null;
            ValidMeasurement.OralGlucoseToleranceTest = null;
            ValidMeasurement.RandomPlasmaGlucoseTest = null;
            ValidMeasurement.Triglyceride = null;
            //Assert
            Assert.ThrowsAsync<ArgumentException>(async () => { await measurementRequest.UpdateMeasurement(ValidMeasurement); });
        }

        [Test]
        public void CreateMeasurement_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await measurementRequest.CreateMeasurement(ValidMeasurementNew); });
        }

        [Test]
        public void CreateMeasurement_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            DiabetesMeasurementsEndpoint measurementRequest = new DiabetesMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidMeasurementNew.CPeptide = null;
            ValidMeasurementNew.FastingPlasmaGlucoseTest = null;
            ValidMeasurementNew.HemoglobinA1c = null;
            ValidMeasurementNew.Insulin = null;
            ValidMeasurementNew.OralGlucoseToleranceTest = null;
            ValidMeasurementNew.RandomPlasmaGlucoseTest = null;
            ValidMeasurementNew.Triglyceride = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await measurementRequest.CreateMeasurement(ValidMeasurementNew); });
        }

        #endregion
    }
}