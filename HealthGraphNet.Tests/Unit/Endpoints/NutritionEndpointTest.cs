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
    public class NutritionEndpointTest
    {
        #region Fields, Properties and Setup

        protected NutritionPastModel ValidNutrition { get; set; }

        protected NutritionNewModel ValidNutritionNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidNutrition = new NutritionPastModel
            {
                Calories = 100
            };

            ValidNutritionNew = new NutritionNewModel
            {
                Timestamp = DateTime.Now,
                Calories = 100,
                PostToFacebook = null,
                PostToTwitter = null
            };
        }

        #endregion

        #region Tests

        [Test()]
        public void GetNutrition_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrow(() => { nutritionRequest.GetNutrition(validPath); });
        }

        [Test()]
        public void GetNutrition_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.GetNutrition("Not validPath."); });
        }

        [Test()]
        public void GetNutritionAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrow(() => { nutritionRequest.GetNutritionAsync((m) => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void GetNutritionAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.GetNutritionAsync((m) => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void DeleteNutrition_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrow(() => { nutritionRequest.DeleteNutrition(validPath); });
        }

        [Test()]
        public void DeleteNutrition_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.DeleteNutrition("Not validPath."); });
        }

        [Test()]
        public void DeleteNutritionAsync_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrow(() => { nutritionRequest.DeleteNutritionAsync(() => { }, (ex) => { }, validPath); });
        }

        [Test()]
        public void DeleteNutritionAsync_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.DeleteNutritionAsync(() => { }, (ex) => { }, "Not validPath."); });
        }

        [Test()]
        public void UpdateNutrition_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { nutritionRequest.UpdateNutrition(ValidNutrition); });
        }

        [Test()]
        public void UpdateNutrition_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidNutrition.Calories = null;
            ValidNutrition.Carbohydrates = null;
            ValidNutrition.Fat = null;
            ValidNutrition.Fiber = null;
            ValidNutrition.Protein = null;
            ValidNutrition.Sodium = null;
            ValidNutrition.Water = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.UpdateNutrition(ValidNutrition); });
        }

        [Test()]
        public void CreateNutrition_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { nutritionRequest.CreateNutrition(ValidNutritionNew); });
        }

        [Test()]
        public void CreateNutrition_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidNutritionNew.Calories = null;
            ValidNutritionNew.Carbohydrates = null;
            ValidNutritionNew.Fat = null;
            ValidNutritionNew.Fiber = null;
            ValidNutritionNew.Protein = null;
            ValidNutritionNew.Sodium = null;
            ValidNutritionNew.Water = null;
            //Assert
            Assert.Throws(typeof(ArgumentException), () => { nutritionRequest.CreateNutrition(ValidNutritionNew); });
        }

        #endregion
    }
}