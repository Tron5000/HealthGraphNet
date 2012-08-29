using System;
using System.Collections.Generic;
using RestSharp;
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
        private UserModel _user;

        #endregion        
        
        #region Constructors

        public FitnessActivitiesEndpoint(AccessTokenManagerBase tokenManager, UserModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region IFitnessActivitiesEndpoint

        public FitnessActivitiesFeedModel GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = PrepareFeedPageRequest(pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FitnessActivitiesFeedModel>(request);
        }

        public void GetFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = PrepareFeedPageRequest(pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FitnessActivitiesFeedModel>(request, success, failure);
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

        #endregion

        #region Helper Methods

        /// <summary>
        /// Prepares the request object to be updated.
        /// </summary>
        /// <param name="activityToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivitiesUpdateRequest(FitnessActivitiesPastModel activityToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = activityToUpdate.Uri;

            //Validate the activityToUpdate properties
            Validate.IsValueValid<string>(activityToUpdate.Type, ValidType, "Type");
            if (activityToUpdate.Type != "Other")
            {
                activityToUpdate.SecondaryType = null;
            }
            if (string.IsNullOrEmpty(activityToUpdate.Equipment))
            {
                activityToUpdate.Equipment = "None";
            }
            Validate.IsValueValid<string>(activityToUpdate.Equipment, ValidEquipment, "Equipment");
            //Also make sure the path type is valid.
            if (activityToUpdate.Path != null)
            {
                foreach (var path in activityToUpdate.Path)
                {
                    Validate.IsValueValid<string>(path.Type, ValidPathType, "Path Type");
                }
            }

            //Add body to the request
            request.AddParameter(FitnessActivitiesPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                type = activityToUpdate.Type,
                secondary_type = activityToUpdate.SecondaryType,
                equipment = activityToUpdate.Equipment,
                //start_time = activityToUpdate.StartTime,
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

        /// <summary>
        /// Adds filtering parameters for the retrieval of a feed page.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="noEarlierThan"></param>
        /// <param name="noLaterThan"></param>
        /// <param name="modifiedNoEarlierThan"></param>
        /// <param name="modifiedNoLaterThan"></param>
        /// <returns></returns>
        private IRestRequest PrepareFeedPageRequest(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)        
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.FitnessActivities;
            string delimiter = "?";
            if (pageIndex.HasValue)
            {
                request.Resource += delimiter + "page={page}";
                request.AddUrlSegment("page", pageIndex.Value.ToString());
                delimiter = "&";
            }
            if (pageSize.HasValue)
            {
                request.Resource += delimiter + "pageSize={pageSize}";
                request.AddUrlSegment("pageSize", pageSize.Value.ToString());
                delimiter = "&";
            }
            if (noEarlierThan.HasValue)
            {
                request.Resource += delimiter + "noEarlierThan={noEarlierThan}";
                request.AddUrlSegment("noEarlierThan", noEarlierThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (noLaterThan.HasValue)
            {
                request.Resource += delimiter + "noLaterThan={noLaterThan}";
                request.AddUrlSegment("noLaterThan", noLaterThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (modifiedNoEarlierThan.HasValue)
            {
                request.Resource += delimiter + "modifiedNoEarlierThan={modifiedNoEarlierThan}";
                request.AddUrlSegment("modifiedNoEarlierThan", modifiedNoEarlierThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (modifiedNoLaterThan.HasValue)
            {
                request.Resource += delimiter + "modifiedNoLaterThan={modifiedNoLaterThan}";
                request.AddUrlSegment("modifiedNoLaterThan", modifiedNoLaterThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            return request;
        }

        #endregion
    }
}