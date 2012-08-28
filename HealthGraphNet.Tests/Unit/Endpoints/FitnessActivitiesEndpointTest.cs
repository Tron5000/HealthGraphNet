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
    public class FitnessActivitiesEndpointTest
    {
        #region Fields, Properties and Setup

        protected FitnessActivitiesPastModel ValidActivity { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidActivity = new FitnessActivitiesPastModel
            {
                Type = FitnessActivitiesEndpoint.ValidType.First(),
                SecondaryType = string.Empty,
                Equipment = FitnessActivitiesEndpoint.ValidEquipment.First(),
                StartTime = DateTime.Now,
                Duration = 120,
                AverageHeartRate = 0,
                HeartRate = null,
                TotalCalories = 500,
                Notes = null,
                Path = null
            };
        }

        #endregion

        #region Tests

        [Test()]
        public void UpdateActivity_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and Assert
            Assert.DoesNotThrow(() => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test()]
        public void UpdateActivity_TypeNotValid_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and assert
            ValidActivity.Type = "Not a valid type.";
            Assert.Throws(typeof(ArgumentException), () => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test()]
        public void UpdateActivity_EquipmentNotValid_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and assert
            ValidActivity.Equipment = "Not a valid equipment.";
            Assert.Throws(typeof(ArgumentException), () => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        #endregion
    }
}