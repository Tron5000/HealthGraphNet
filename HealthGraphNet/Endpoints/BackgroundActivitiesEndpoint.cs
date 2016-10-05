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
    /// For http://developer.runkeeper.com/healthgraph/background-activities
    /// </summary>
    public class BackgroundActivitiesEndpoint : IBackgroundActivitiesEndpoint
    {
        #region Fields and Properties

        private Client _tokenManager;
        private UsersModel _user;

        #endregion
        
        #region Constructors

        public BackgroundActivitiesEndpoint(Client tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion 
        
        #region IBackgroundActivitiesEndpoint

        public async Task<FeedModel<BackgroundActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.BackgroundActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<BackgroundActivitiesFeedItemModel>>(request);
        }

        public async Task<BackgroundActivitiesPastModel> GetActivity(string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            request.Resource = uri;
            return await _tokenManager.Execute<BackgroundActivitiesPastModel>(request);
        }

        public async Task<BackgroundActivitiesPastModel> UpdateActivity(BackgroundActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivityUpdateRequest(activityToUpdate);
            return await _tokenManager.Execute<BackgroundActivitiesPastModel>(request);
        }

        public async Task<string> CreateActivity(BackgroundActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivityCreateRequest(activityToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteActivity(string uri)
        {
            if (uri.Contains(_user.BackgroundActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.BackgroundActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.DELETE);
            await _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
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
            var request = new RestRequest(_user.BackgroundActivities, Method.POST);

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
            var request = new RestRequest(activityToUpdate.Uri, Method.PUT);

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