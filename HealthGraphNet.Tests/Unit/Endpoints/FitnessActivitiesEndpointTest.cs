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
                Path = new List<PathModel>
                {
                    new PathModel
                    {
                        Timestamp = 0,
                        Latitude = 100.0,
                        Longitude = 100.0,
                        Altitude = 100.0,
                        Type = FitnessActivitiesEndpoint.ValidPathType.First()
                    },
                    new PathModel
                    {
                        Timestamp = 60,
                        Latitude = 120.0,
                        Longitude = 120.0,
                        Altitude = 50.0,
                        Type = FitnessActivitiesEndpoint.ValidPathType.First()
                    }
                }
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

        [Test()]
        public void UpdateActivity_PathTypeNotValid_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and assert
            ValidActivity.Path.First().Type = "Not a valid path type.";
            Assert.Throws(typeof(ArgumentException), () => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test()]
        public void UpdateActivity_OnePathItemInArray_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and assert
            ValidActivity.Path.RemoveAt(1);
            Assert.AreEqual(1, ValidActivity.Path.Count);
            Assert.Throws(typeof(ArgumentException), () => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test()]
        public void UpdateActivity_TypeOtherSecondaryTypeSixtyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<AccessTokenManagerBaseStub> tokenManager = new Mock<AccessTokenManagerBaseStub>();
            FitnessActivitiesEndpoint activitiesRequest = new FitnessActivitiesEndpoint(tokenManager.Object, new UserModel());
            //Act and assert
            ValidActivity.Type = "Other";
            string sixtyFiveCharacterSecondaryType = string.Empty;
            for (var count = 0; count < 65; count++)
            {
                sixtyFiveCharacterSecondaryType += "A";
            }
            ValidActivity.SecondaryType = sixtyFiveCharacterSecondaryType;
            Assert.AreEqual(65, ValidActivity.SecondaryType.Length);
            Assert.Throws(typeof(ArgumentException), () => { activitiesRequest.UpdateActivity(ValidActivity); });
        }

        #endregion
    }
}