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
    public class GeneralMeasurementsEndpointTest
    {
        #region Fields, Properties and Setup

        protected GeneralMeasurementsPastModel ValidMeasurement { get; set; }

        protected GeneralMeasurementsNewModel ValidMeasurementNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidMeasurement = new GeneralMeasurementsPastModel
            {
                RestingHeartrate = 90
            };

            ValidMeasurementNew = new GeneralMeasurementsNewModel
            {
                Timestamp = DateTime.Now,
                RestingHeartrate = 90,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion    

        #region Tests

        [Test()]
        public void GetMeasurement_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.GetMeasurement(validPath); });
        }

        [Test()]
        public void GetMeasurement_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.GetMeasurement("Not validPath."); });
        }

        [Test()]
        public void GetMeasurementAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.GetMeasurementAsync((m) => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void GetMeasurementAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.GetMeasurementAsync((m) => { }, (ex) => { }, "Not validPath."); });
        }


        [Test()]
        public void DeleteMeasurement_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.DeleteMeasurement(validPath); });
        }

        [Test()]
        public void DeleteMeasurement_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.DeleteMeasurement("Not validPath."); });
        }

        [Test()]
        public void DeleteMeasurementAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.DeleteMeasurementAsync(() => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void DeleteMeasurementAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel { GeneralMeasurements = validPath });
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.DeleteMeasurementAsync(() => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void UpdateMeasurement_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.UpdateMeasurement(ValidMeasurement); });
        }

        [Test()]
        public void UpdateMeasurement_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act            
            ValidMeasurement.BloodCalcium = null;
            ValidMeasurement.BloodChromium = null;
            ValidMeasurement.BloodFolicAcid = null;
            ValidMeasurement.BloodMagnesium = null;
            ValidMeasurement.BloodPotassium = null;
            ValidMeasurement.BloodSodium = null;
            ValidMeasurement.BloodVitaminB12 = null;
            ValidMeasurement.BloodZinc = null;
            ValidMeasurement.CreatineKinase = null;
            ValidMeasurement.Crp = null;
            ValidMeasurement.Diastolic = null;
            ValidMeasurement.Ferritin = null;
            ValidMeasurement.Hdl = null;
            ValidMeasurement.Hscrp = null;
            ValidMeasurement.Il6 = null;
            ValidMeasurement.Ldl = null;
            ValidMeasurement.RestingHeartrate = null;
            ValidMeasurement.Systolic = null;
            ValidMeasurement.Testosterone = null;
            ValidMeasurement.TotalCholesterol = null;
            ValidMeasurement.Tsh = null;
            ValidMeasurement.UricAcid = null;
            ValidMeasurement.VitaminD = null;
            ValidMeasurement.WhiteCellCount = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.UpdateMeasurement(ValidMeasurement); });
        }

        [Test()]
        public void CreateMeasurement_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { measurementRequest.CreateMeasurement(ValidMeasurementNew); });
        }

        [Test()]
        public void CreateMeasurement_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            GeneralMeasurementsEndpoint measurementRequest = new GeneralMeasurementsEndpoint(tokenManager.Object, new UsersModel());
            //Act            
            ValidMeasurementNew.BloodCalcium = null;
            ValidMeasurementNew.BloodChromium = null;
            ValidMeasurementNew.BloodFolicAcid = null;
            ValidMeasurementNew.BloodMagnesium = null;
            ValidMeasurementNew.BloodPotassium = null;
            ValidMeasurementNew.BloodSodium = null;
            ValidMeasurementNew.BloodVitaminB12 = null;
            ValidMeasurementNew.BloodZinc = null;
            ValidMeasurementNew.CreatineKinase = null;
            ValidMeasurementNew.Crp = null;
            ValidMeasurementNew.Diastolic = null;
            ValidMeasurementNew.Ferritin = null;
            ValidMeasurementNew.Hdl = null;
            ValidMeasurementNew.Hscrp = null;
            ValidMeasurementNew.Il6 = null;
            ValidMeasurementNew.Ldl = null;
            ValidMeasurementNew.RestingHeartrate = null;
            ValidMeasurementNew.Systolic = null;
            ValidMeasurementNew.Testosterone = null;
            ValidMeasurementNew.TotalCholesterol = null;
            ValidMeasurementNew.Tsh = null;
            ValidMeasurementNew.UricAcid = null;
            ValidMeasurementNew.VitaminD = null;
            ValidMeasurementNew.WhiteCellCount = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { measurementRequest.CreateMeasurement(ValidMeasurementNew); });
        }

        #endregion
    }
}