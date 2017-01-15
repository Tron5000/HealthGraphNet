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
    public class SettingsEndpointTest
    {
        #region Fields, Properties and Setup

        protected SettingsModel ValidSettings { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidSettings = new SettingsModel
            {
                ShareFitnessActivities = SettingsEndpoint.ValidVisibility.First(),
                ShareMap = SettingsEndpoint.ValidVisibility.First(),
                PostFitnessActivityFacebook = false,
                PostFitnessActivityTwitter = false,
                PostLiveFitnessActivityFacebook = false,
                PostLiveFitnessActivityTwitter = false,
                ShareBackgroundActivities = SettingsEndpoint.ValidVisibility.First(),
                PostBackgroundActivityFacebook = false,
                PostBackgroundActivityTwitter = false,
                ShareSleep = SettingsEndpoint.ValidVisibility.First(),
                PostSleepFacebook = false,
                PostSleepTwitter = false,
                ShareNutrition = SettingsEndpoint.ValidVisibility.First(),
                PostNutritionFacebook = false,
                PostNutritionTwitter = false,
                ShareWeight = SettingsEndpoint.ValidVisibility.First(),
                PostWeightFacebook = false,
                PostWeightTwitter = false,
                ShareGeneralMeasurements = SettingsEndpoint.ValidVisibility.First(),
                PostGeneralMeasurementsFacebook = false,
                PostGeneralMeasurementsTwitter = false,
                ShareDiabetes = SettingsEndpoint.ValidVisibility.First(),
                PostDiabetesFacebook = false,
                PostDiabetesTwitter = false,
                DistanceUnits = SettingsEndpoint.ValidDistanceUnit.First(),
                WeightUnits = SettingsEndpoint.ValidWeightUnit.First(),
                FirstDayOfWeek = SettingsEndpoint.ValidFirstDayOfWeek.First()
            };
        }

        #endregion

        #region Tests

        [Test]
        public void UpdateSettings_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareFitnessActivitiesNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareFitnessActivities = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareMapNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareMap = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareBackgroundActivitiesNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareBackgroundActivities = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareSleepNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareSleep = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareNutritionNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareNutrition = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareWeightNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareWeight = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareGeneralMeasurementsNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareGeneralMeasurements = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_ShareDiabetesNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.ShareDiabetes = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_DistanceUnitsNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.DistanceUnits = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_WeightUnitsNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.WeightUnits = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        [Test]
        public void UpdateSettings_FirstDayOfWeekNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            SettingsEndpoint settingsRequest = new SettingsEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            ValidSettings.FirstDayOfWeek = "Not valid value.";
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await settingsRequest.UpdateSettings(ValidSettings); });
        }

        #endregion
    }
}