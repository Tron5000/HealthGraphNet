using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HealthGraphNet;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet.Tests.Integration
{
    [TestFixture()]
    public class UsersEndpointTest : AccessTokenManagerSetupBase
    {        
        #region Tests

        [Test]
        public async Task GetUser_NotOptionalProperiesPresent()
        {
            //Arrange
            var userRequest = new UsersEndpoint(TokenManager);
            //Act
            var user = await userRequest.GetUser();
            //Assert
            Assert.IsTrue(user.UserID != default(int));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Profile));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Settings));
            Assert.IsTrue(!string.IsNullOrEmpty(user.FitnessActivities));
            Assert.IsTrue(!string.IsNullOrEmpty(user.StrengthTrainingActivities));
            Assert.IsTrue(!string.IsNullOrEmpty(user.BackgroundActivities));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Sleep));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Nutrition));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Weight));
            Assert.IsTrue(!string.IsNullOrEmpty(user.GeneralMeasurements));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Diabetes));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Records));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Team));        
        }

        #endregion
    }
}