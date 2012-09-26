using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet
{
    /// <summary>
    /// For http://developer.runkeeper.com/healthgraph/background-activities
    /// </summary>
    public class BackgroundActivitiesEndpoint : IBackgroundActivitiesEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion
        
        #region Constructors

        public BackgroundActivitiesEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion 
        
        #region IBackgroundActivitiesEndpoint

        public FeedModel<BackgroundActivitiesFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.BackgroundActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<BackgroundActivitiesFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<BackgroundActivitiesFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.BackgroundActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<BackgroundActivitiesFeedItemModel>>(request, success, failure);
        }

        public BackgroundActivitiesPastModel GetActivity(string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<BackgroundActivitiesPastModel>(request);
        }

        public void GetActivityAsync(Action<BackgroundActivitiesPastModel> success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<BackgroundActivitiesPastModel>(request, success, failure);
        }

        public BackgroundActivitiesPastModel UpdateActivity(BackgroundActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivityUpdateRequest(activityToUpdate);
            return _tokenManager.Execute<BackgroundActivitiesPastModel>(request);
        }

        public void UpdateActivityAsync(Action<BackgroundActivitiesPastModel> success, Action<HealthGraphException> failure, BackgroundActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivityUpdateRequest(activityToUpdate);
            _tokenManager.ExecuteAsync<BackgroundActivitiesPastModel>(request, success, failure);
        }

        public string CreateActivity(BackgroundActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivityCreateRequest(activityToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public void CreateActivityAsync(Action<string> success, Action<HealthGraphException> failure, BackgroundActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivityCreateRequest(activityToCreate);
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void DeleteActivity(string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        public void DeleteActivityAsync(Action success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.ExecuteAsync(request, success, failure, expectedStatusCode: HttpStatusCode.NoContent);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Performs validation logic prior to an update or create.
        /// </summary>
        /// <param name="activityToValidate"></param>
        private void ValidateModel(BackgroundActivitiesModelBase activityToValidate)
        {
            if ((activityToValidate.Measurement.HasValue == false) || (activityToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: CaloriesBurned or Steps.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="activityToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivityCreateRequest(BackgroundActivitiesNewModel activityToCreate)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = _user.BackgroundActivities;

            ValidateModel(activityToCreate);

            //Add body to the request
            request.AddParameter(BackgroundActivitiesNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = activityToCreate.Timestamp.ToUniversalTime(),
                calories_burned = activityToCreate.CaloriesBurned,
                steps = activityToCreate.Steps,
                post_to_twitter = activityToCreate.PostToTwitter,
                post_to_facebook = activityToCreate.PostToFacebook
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="activityToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivityUpdateRequest(BackgroundActivitiesPastModel activityToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = activityToUpdate.Uri;

            ValidateModel(activityToUpdate);

            //Add body to the request
            request.AddParameter(BackgroundActivitiesPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                calories_burned = activityToUpdate.CaloriesBurned,
                steps = activityToUpdate.Steps
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}