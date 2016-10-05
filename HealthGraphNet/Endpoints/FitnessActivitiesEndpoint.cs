using System;
using System.Collections.Generic;
using System.Net;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// For  http://developer.runkeeper.com/healthgraph/fitness-activities
    /// </summary>
    public class FitnessActivitiesEndpoint : EndPointBase, IFitnessActivitiesEndpoint
    {
        #region Fields and Properties

        //public static readonly List<string> ValidType = new List<string> { "Running", "Cycling", "Mountain Biking", "Walking", "Hiking", "Downhill Skiing", "Cross-Country Skiing", "Snowboarding", "Skating", "Swimming", "Wheelchair", "Rowing", "Elliptical", "Other" };
        public static readonly List<string> ValidEquipment = new List<string> { "None", "Treadmill", "Stationary Bike", "Elliptical", "Row Machine" };
        public static readonly List<string> ValidPathType = new List<string> { "start", "end", "gps", "pause", "resume", "manual" };

        #endregion

        #region Constructors

        public FitnessActivitiesEndpoint(Client client, UsersModel user) : base(client, user)
        {
        }

        public FitnessActivitiesEndpoint(Client client, Func<Task<UsersModel>> functionGetUser) : base(client, functionGetUser)
        {
        }

        #endregion

        #region IFitnessActivitiesEndpoint

        /// <summary>
        /// Retrieve user's activity history
        /// </summary>
        /// <param name="pageIndex">Zero based index of the desired page.</param>
        /// <param name="pageSize"></param>
        /// <param name="noEarlierThan"></param>
        /// <param name="noLaterThan"></param>
        /// <param name="modifiedNoEarlierThan"></param>
        /// <param name="modifiedNoLaterThan"></param>
        /// <returns></returns>
        public async Task<FeedModel<FitnessActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var user = await GetUser();
            var request = ExtensionHelpers.CreateFeedPageRequest(user.FitnessActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await Client.Execute<FeedModel<FitnessActivitiesFeedItemModel>>(request);
        }

        public async Task<FitnessActivitiesPastModel> GetActivity(string uri)
        {
            var user = await GetUser();
            if (uri.Contains(user.FitnessActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + user.FitnessActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            request.Resource = uri;
            return await Client.Execute<FitnessActivitiesPastModel>(request);
        }

        public async Task<FitnessActivitiesPastModel> UpdateActivity(FitnessActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivitiesUpdateRequest(activityToUpdate);
            return await Client.Execute<FitnessActivitiesPastModel>(request);
        }

        public async Task<string> CreateActivity(FitnessActivitiesNewModel activityToCreate)
        {
            var user = await GetUser();
            var request = PrepareActivitiesCreateRequest(activityToCreate, user);
            return await Client.ExecuteCreate(request);
        }

        public async Task DeleteActivity(string uri)
        {
            var user = await GetUser();
            if (uri.Contains(user.FitnessActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + user.FitnessActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.DELETE);
            await Client.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Performs validation logic prior to an update or create.
        /// </summary>
        /// <param name="activityToValidate"></param>
        private void ValidateModel(IFitnessActivitiesModel activityToValidate)
        {
            //Validate the activityToValidate properties
            //ValidateHelper.IsValueValid<string>(activityToValidate.Type, ValidType, "Type");
            if (activityToValidate.Type != FitnessActivityType.Other)
            {
                activityToValidate.SecondaryType = null;
            }
            else
            {
                ValidateHelper.IsValidLength(activityToValidate.SecondaryType, 64);
            }
            if (string.IsNullOrEmpty(activityToValidate.Equipment))
            {
                activityToValidate.Equipment = "None";
            }
            ValidateHelper.IsValueValid<string>(activityToValidate.Equipment, ValidEquipment, "Equipment");
            //Also make sure the path type is valid.
            if (activityToValidate.Path != null)
            {
                if (activityToValidate.Path.Count == 1)
                {
                    throw new ArgumentException("When defining a non-empty Path collection, more than one Path must be present.");
                }
                foreach (var path in activityToValidate.Path)
                {
                    ValidateHelper.IsValueValid<string>(path.Type, ValidPathType, "Path Type");
                }
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="activityToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivitiesCreateRequest(FitnessActivitiesNewModel activityToCreate, UsersModel user)
        {
            var request = new RestRequest(user.FitnessActivities, Method.POST);

            ValidateModel(activityToCreate);

            //Add body to the request
            request.AddParameter(FitnessActivitiesNewModel.ContentType, Client.DefaultJsonSerializer.Serialize(new
            {
                type = activityToCreate.Type,
                secondary_type = activityToCreate.SecondaryType,
                equipment = activityToCreate.Equipment,
                start_time = activityToCreate.StartTime,
                total_distance = activityToCreate.TotalDistance,
                duration = activityToCreate.Duration,
                average_heart_rate = activityToCreate.AverageHeartRate,
                heart_rate = activityToCreate.HeartRate,
                total_calories = activityToCreate.TotalCalories,
                notes = activityToCreate.Notes,
                path = ((activityToCreate.Path != null) && (activityToCreate.Path.Count == 0)) ? null : activityToCreate.Path,
                post_to_facebook = activityToCreate.PostToFacebook,
                post_to_twitter = activityToCreate.PostToTwitter,
                detect_pauses = activityToCreate.DetectPauses
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="activityToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivitiesUpdateRequest(FitnessActivitiesPastModel activityToUpdate)
        {
            var request = new RestRequest(activityToUpdate.Uri, Method.PUT);

            ValidateModel(activityToUpdate);

            //Add body to the request
            request.AddParameter(FitnessActivitiesPastModel.ContentType, Client.DefaultJsonSerializer.Serialize(new
            {
                type = activityToUpdate.Type,
                secondary_type = activityToUpdate.SecondaryType,
                equipment = activityToUpdate.Equipment,
                start_time = activityToUpdate.StartTime,
                total_distance = activityToUpdate.TotalDistance,
                duration = activityToUpdate.Duration,
                average_heart_rate = activityToUpdate.AverageHeartRate,
                heart_rate = activityToUpdate.HeartRate,
                total_calories = activityToUpdate.TotalCalories,
                notes = activityToUpdate.Notes,
                path = ((activityToUpdate.Path != null) && (activityToUpdate.Path.Count == 0)) ? null : activityToUpdate.Path
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}