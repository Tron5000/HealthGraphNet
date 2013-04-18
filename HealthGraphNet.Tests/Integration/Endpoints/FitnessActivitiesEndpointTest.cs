using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Tests.Integration
{
    [TestFixture()]    
    public class FitnessActivitiesEndpointTest : AccessTokenManagerSetupBase
    {
        #region Fields, Properties and Setup

        protected IUsersEndpoint UserRequest { get; set; }

        protected IFitnessActivitiesEndpoint ActivitiesRequest { get; set; }

        [SetUp()]
        public void Init()
        {
            UserRequest = new UsersEndpoint(TokenManager);
            var user = UserRequest.GetUser();
            ActivitiesRequest = new FitnessActivitiesEndpoint(TokenManager, user);
        }

        #endregion    
    
        #region Tests

        [Test()]
        public void FitnessActivity_CRUD()
        {
            // FYI - For comparing dates Healthgraph API doesn't seem to support fidelity down to the millisecond level.            
            //Create
            var newActivity = new FitnessActivitiesNewModel
            {
                Type = "Running",
                Equipment = "Treadmill",
                StartTime = DateTime.Now,
                TotalDistance = 237903.79842947799d,
                Duration = 120,
                AverageHeartRate = 100,
                HeartRate = new List<HeartRateModel> { new HeartRateModel { Timestamp = 60, HeartRate = 100 } },
                TotalCalories = 44,                
                Notes = "Integration test!",
                Path = new List<PathModel> 
                { 
                    new PathModel { Timestamp = 0, Latitude = 100, Longitude = 100, Altitude = 0, Type = "start" }, 
                    new PathModel { Timestamp = 120, Latitude = 102, Longitude = 104, Altitude = 0, Type = "end" }
                },
                PostToFacebook = false,
                PostToTwitter = false,
                DetectPauses = false
            };
            var uri = ActivitiesRequest.CreateActivity(newActivity);
            Assert.IsTrue(!string.IsNullOrEmpty(uri));

            //Read from Feed
            var activitiesItem = ActivitiesRequest.GetFeedPage().Items.FirstOrDefault();
            Assert.IsNotNull(activitiesItem);
            Assert.AreEqual(newActivity.Type, activitiesItem.Type);
            Assert.AreEqual(newActivity.StartTime.ToString(), activitiesItem.StartTime.ToString());
            Assert.AreEqual(newActivity.TotalDistance, activitiesItem.TotalDistance);
            Assert.AreEqual(newActivity.Duration, activitiesItem.Duration);
            Assert.AreEqual(uri, activitiesItem.Uri);

            /*
            //Read from past
            var activitiesDetail = ActivitiesRequest.GetActivity(uri);
            AssertFitnessActivities(newActivity, activitiesDetail);
            Assert.AreEqual(newActivity.TotalCalories, activitiesDetail.TotalCalories);
            Assert.AreEqual(uri, activitiesDetail.Uri);

            //Update
            activitiesDetail.Type = "Hiking";
            activitiesDetail.Equipment = "None";
            activitiesDetail.StartTime = activitiesDetail.StartTime.AddHours(1);
            var activitiesDetailUpdated = ActivitiesRequest.UpdateActivity(activitiesDetail);
            AssertFitnessActivities(activitiesDetail, activitiesDetailUpdated);
            Assert.AreEqual(activitiesDetail.TotalCalories, activitiesDetailUpdated.TotalCalories);
            Assert.AreEqual(uri, activitiesDetailUpdated.Uri);
            */
              
            //Delete
            ActivitiesRequest.DeleteActivity(uri);           
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Assert expected and actual of IFitnessActivitiesModel.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="uri"></param>
        /*
        public void AssertFitnessActivities(IFitnessActivitiesModel expected, IFitnessActivitiesModel actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Equipment, actual.Equipment);
            Assert.AreEqual(expected.StartTime.ToString(), actual.StartTime.ToString());
            Assert.AreEqual(expected.TotalDistance, actual.TotalDistance);
            Assert.AreEqual(expected.Duration, actual.Duration);
            Assert.AreEqual(expected.AverageHeartRate, actual.AverageHeartRate);
            Assert.AreEqual(expected.HeartRate[0].Timestamp, actual.HeartRate[0].Timestamp);
            Assert.AreEqual(expected.HeartRate[0].HeartRate, actual.HeartRate[0].HeartRate);
            Assert.AreEqual(expected.Notes, actual.Notes);
            Assert.AreEqual(expected.Path[0].Timestamp, actual.Path[0].Timestamp);
            Assert.AreEqual(expected.Path[0].Latitude, actual.Path[0].Latitude);
            Assert.AreEqual(expected.Path[0].Longitude, actual.Path[0].Longitude);
            Assert.AreEqual(expected.Path[0].Altitude, actual.Path[0].Altitude);
            Assert.AreEqual(expected.Path[0].Type, actual.Path[0].Type);
            Assert.AreEqual(expected.Path[1].Timestamp, actual.Path[1].Timestamp);
            Assert.AreEqual(expected.Path[1].Latitude, actual.Path[1].Latitude);
            Assert.AreEqual(expected.Path[1].Longitude, actual.Path[1].Longitude);
            Assert.AreEqual(expected.Path[1].Altitude, actual.Path[1].Altitude);
            Assert.AreEqual(expected.Path[1].Type, actual.Path[1].Type);
        }
        */
          
        #endregion
    }
}