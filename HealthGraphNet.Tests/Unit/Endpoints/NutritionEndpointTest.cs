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

        [Test]
        public void GetNutrition_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrowAsync(async() => { await nutritionRequest.GetNutrition(validPath); });
        }

        [Test]
        public void GetNutrition_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await nutritionRequest.GetNutrition("Not validPath."); });
        }

        [Test]
        public void DeleteNutrition_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.DoesNotThrowAsync(async () => { await nutritionRequest.DeleteNutrition(validPath); });
        }

        [Test]
        public void DeleteNutrition_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel { Nutrition = validPath });
            //Act and assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await nutritionRequest.DeleteNutrition("Not validPath."); });
        }

        [Test]
        public void UpdateNutrition_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await nutritionRequest.UpdateNutrition(ValidNutrition); });
        }

        [Test]
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
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await nutritionRequest.UpdateNutrition(ValidNutrition); });
        }

        [Test]
        public void CreateNutrition_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            NutritionEndpoint nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await nutritionRequest.CreateNutrition(ValidNutritionNew); });
        }

        [Test]
        public void CreateNutrition_AllMeasurementsNull_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            var nutritionRequest = new NutritionEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidNutritionNew.Calories = null;
            ValidNutritionNew.Carbohydrates = null;
            ValidNutritionNew.Fat = null;
            ValidNutritionNew.Fiber = null;
            ValidNutritionNew.Protein = null;
            ValidNutritionNew.Sodium = null;
            ValidNutritionNew.Water = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await nutritionRequest.CreateNutrition(ValidNutritionNew); });
        }

        #endregion
    }
}