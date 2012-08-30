using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet
{
    /// <summary>
    /// For  http://developer.runkeeper.com/healthgraph/fitness-activities
    /// </summary>
    public class FitnessActivitiesEndpoint : IFitnessActivitiesEndpoint
    {
        #region Fields and Properties

        public static readonly List<string> ValidType = new List<string> { "Running", "Cycling", "Mountain Biking", "Walking", "Hiking", "Downhill Skiing", "Cross-Country Skiing", "Snowboarding", "Skating", "Swimming", "Wheelchair", "Rowing", "Elliptical", "Other" };
        public static readonly List<string> ValidEquipment = new List<string> { "None", "Treadmill", "Stationary Bike", "Elliptical", "Row Machine" };
        public static readonly List<string> ValidPathType = new List<string> { "start", "end", "gps", "pause", "resume", "manual" };

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion        
        
        #region Constructors

        public FitnessActivitiesEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region IFitnessActivitiesEndpoint

        public FeedModel<FitnessActivitiesFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.FitnessActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<FitnessActivitiesFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<FitnessActivitiesFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.FitnessActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<FitnessActivitiesFeedItemModel>>(request, success, failure);
        }

        public FitnessActivitiesPastModel GetActivity(string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<FitnessActivitiesPastModel>(request);
        }

        public void GetActivityAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync(request, success, failure);
        }

        public FitnessActivitiesPastModel UpdateActivity(FitnessActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivitiesUpdateRequest(activityToUpdate);
            return _tokenManager.Execute<FitnessActivitiesPastModel>(request);
        }

        public void UpdateSettingsAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, FitnessActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivitiesUpdateRequest(activityToUpdate);
            _tokenManager.ExecuteAsync<FitnessActivitiesPastModel>(request, success, failure);
        }

        public string CreateActivity(FitnessActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivitiesCreateRequest(activityToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public void CreateActivityAsync(Action<string> success, Action<HealthGraphException> failure, FitnessActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivitiesCreateRequest(activityToCreate);
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void DeleteActivity(string uri)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.ExecuteDelete(request);
        }

        public void DeleteActivityAsync(Action success, Action<HealthGraphException> failure, string uri)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.ExecuteDeleteAsync(request, success, failure);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Performs validation logic prior to an update or create.
        /// </summary>
        /// <param name="activityToValidate"></param>
        private void ValidateModel(IFitnessActivitiesModel activityToValidate)
        {
            //Validate the activityToUpdate properties
            ValidateHelper.IsValueValid<string>(activityToValidate.Type, ValidType, "Type");
            if (activityToValidate.Type != "Other")
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
        private IRestRequest PrepareActivitiesCreateRequest(FitnessActivitiesNewModel activityToCreate)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = _user.FitnessActivities;

            ValidateModel(activityToCreate);

            //Add body to the request
            request.AddParameter(FitnessActivitiesNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
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
            var request = new RestRequest(Method.PUT);
            request.Resource = activityToUpdate.Uri;

            ValidateModel(activityToUpdate);

            //Add body to the request
            request.AddParameter(FitnessActivitiesPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
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