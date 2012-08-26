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

        public FitnessActivitiesFeedModel GetMostRecentFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = PrepareFeedPageRequest(pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FitnessActivitiesFeedModel>(request);
        }

        public void GetMostRecentFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = PrepareFeedPageRequest(pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FitnessActivitiesFeedModel>(request, success, failure);
        }

        public FitnessActivitiesFeedModel GetNextFeedPage(FitnessActivitiesFeedModel currentFeedPage)
        {
            if (string.IsNullOrEmpty(currentFeedPage.Next))
            {
                //No next page of feed activity exists
                return null;
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentFeedPage.Next;
                return _tokenManager.Execute<FitnessActivitiesFeedModel>(request);
            }
        }

        public void GetNextFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedModel currentFeedPage)
        {
            if (string.IsNullOrEmpty(currentFeedPage.Next))
            {
                //No next page of feed activity exists
                success(null);
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentFeedPage.Next;
                _tokenManager.ExecuteAsync<FitnessActivitiesFeedModel>(request, success, failure);
            }
        }

        public FitnessActivitiesFeedModel GetPrevFeedPage(FitnessActivitiesFeedModel currentFeedPage)
        {
            if (string.IsNullOrEmpty(currentFeedPage.Previous))
            {
                //No prev page of feed activity exists
                return null;
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentFeedPage.Previous;
                return _tokenManager.Execute<FitnessActivitiesFeedModel>(request);
            }
        }

        public void GetPrevFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedModel currentFeedPage)
        {
            if (string.IsNullOrEmpty(currentFeedPage.Previous))
            {
                //No prev page of feed activity exists
                success(null);
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentFeedPage.Previous;
                _tokenManager.ExecuteAsync<FitnessActivitiesFeedModel>(request, success, failure);
            }
        }

        public FitnessActivitiesModel GetActivity(FitnessActivitiesFeedItemModel currentFeedItem)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = currentFeedItem.Uri;
            return _tokenManager.Execute<FitnessActivitiesModel>(request);
        }

        public void GetActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedItemModel currentFeedItem)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = currentFeedItem.Uri;
            _tokenManager.ExecuteAsync(request, success, failure);
        }

        public FitnessActivitiesModel GetNextActivity(FitnessActivitiesModel currentActivity)
        {
            if (string.IsNullOrEmpty(currentActivity.Next))
            {
                return null;
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentActivity.Next;
                return _tokenManager.Execute<FitnessActivitiesModel>(request);
            }
        }

        public void GetNextActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity)
        {
            if (string.IsNullOrEmpty(currentActivity.Next))
            {
                success(null);
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentActivity.Next;
                _tokenManager.ExecuteAsync<FitnessActivitiesModel>(request, success, failure);
            }
        }

        public FitnessActivitiesModel GetPrevActivity(FitnessActivitiesModel currentActivity)
        {
            if (string.IsNullOrEmpty(currentActivity.Previous))
            {
                return null;
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentActivity.Previous;
                return _tokenManager.Execute<FitnessActivitiesModel>(request);
            }
        }

        public void GetPrevActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity)
        {
            if (string.IsNullOrEmpty(currentActivity.Previous))
            {
                success(null);
            }
            else
            {
                var request = new RestRequest(Method.GET);
                request.Resource = currentActivity.Previous;
                _tokenManager.ExecuteAsync<FitnessActivitiesModel>(request, success, failure);
            }
        }

        public FitnessActivitiesModel UpdateActivity(FitnessActivitiesModel activityToUpdate)
        {
            var request = PrepareActivitiesUpdateRequest(activityToUpdate);
            return _tokenManager.Execute<FitnessActivitiesModel>(request);
        }

        public void UpdateSettingsAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel activityToUpdate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods

        private IRestRequest PrepareActivitiesUpdateRequest(FitnessActivitiesModel activityToUpdate)
        {
            throw new NotImplementedException();
        }

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