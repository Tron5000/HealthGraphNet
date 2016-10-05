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
    public class ProfileEndpointTest : ClientSetupBase
    {
        #region Fields, Properties and Setup

        protected IUsersEndpoint UserRequest { get; set; }

        protected IProfileEndpoint ProfileRequest { get; set; }

        [SetUp]
        public void Init()
        {
            UserRequest = new UsersEndpoint(TokenManager);
            var user = UserRequest.GetUser().Result;
            ProfileRequest = new ProfileEndpoint(TokenManager, user);
        }

        #endregion

        #region Tests

        [Test]
        public async Task GetProfile_NotOptionalPropertiesPresent()
        {
            //Arrange
            //Act
            var profile = await ProfileRequest.GetProfile();
            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(profile.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(profile.Profile));
        }

        //[Test]
        //public async Task UpdateProfile_AthleteTypeUpdated()
        //{
        //    //Arrange
        //    var profile = await ProfileRequest.GetProfile();
        //    string originalAthleteType = profile.AthleteType;
        //    string newAthleteType;
        //    var athleteTypeCount = 0;
        //    // Make sure the new athlete type doesn't match whatever's already there.
        //    do
        //    {
        //        newAthleteType = ProfileEndpoint.ValidAthleteType.ElementAt(athleteTypeCount);
        //        athleteTypeCount++;
        //    } while (newAthleteType == originalAthleteType);
        //    //Act
        //    profile.AthleteType = newAthleteType;
        //    profile = await ProfileRequest.UpdateProfile(profile);
        //    //Assert
        //    Assert.AreEqual(newAthleteType, profile.AthleteType);

        //    //Cleanup - set profile type back to original value.
        //    profile.AthleteType = originalAthleteType;
        //    profile = await ProfileRequest.UpdateProfile(profile);
        //}

        #endregion
    }
}