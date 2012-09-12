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
    /// For http://developer.runkeeper.com/healthgraph/sleep
    /// </summary>
    public class SleepEndpoint : ISleepEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion    

        #region Constructors

        public SleepEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion     
    
        #region ISleepEndpoint

        public FeedModel<SleepFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Sleep, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<SleepFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<SleepFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Sleep, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<SleepFeedItemModel>>(request, success, failure); 
        }

        public SleepPastModel GetSleep(string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<SleepPastModel>(request);
        }

        public void GetSleepAsync(Action<SleepPastModel> success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<SleepPastModel>(request, success, failure);
        }

        public SleepPastModel UpdateSleep(SleepPastModel sleepToUpdate)
        {
            var request = PrepareSleepUpdateRequest(sleepToUpdate);
            return _tokenManager.Execute<SleepPastModel>(request);
        }

        public void UpdateSleepAsync(Action<SleepPastModel> success, Action<HealthGraphException> failure, SleepPastModel sleepToUpdate)
        {
            var request = PrepareSleepUpdateRequest(sleepToUpdate);
            _tokenManager.ExecuteAsync<SleepPastModel>(request, success, failure);
        }

        public string CreateSleep(SleepNewModel sleepToCreate)
        {
            var request = PrepareSleepCreateRequest(sleepToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public void CreateSleepAsync(Action<string> success, Action<HealthGraphException> failure, SleepNewModel sleepToCreate)
        {
            var request = PrepareSleepCreateRequest(sleepToCreate);
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void DeleteSleep(string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
            }
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        public void DeleteSleepAsync(Action success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
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
        /// <param name="sleepToValidate"></param>
        private void ValidateModel(SleepModelBase sleepToValidate)
        {
            if ((sleepToValidate.Measurement.HasValue == false) || (sleepToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: Awake, Deep, Light, Rem, TimesWoken, or TotalSleep.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="sleepToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareSleepCreateRequest(SleepNewModel sleepToCreate)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = _user.Sleep;

            ValidateModel(sleepToCreate);

            //Add body to the request
            request.AddParameter(SleepNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = sleepToCreate.Timestamp.ToUniversalTime(),
                awake = sleepToCreate.Awake,
                deep = sleepToCreate.Deep,
                light = sleepToCreate.Light,
                rem = sleepToCreate.Rem,
                times_woken = sleepToCreate.TimesWoken,
                total_sleep = sleepToCreate.TotalSleep,
                post_to_twitter = sleepToCreate.PostToTwitter,
                post_to_facebook = sleepToCreate.PostToFacebook
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="sleepToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareSleepUpdateRequest(SleepPastModel sleepToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = sleepToUpdate.Uri;

            ValidateModel(sleepToUpdate);

            //Add body to the request
            request.AddParameter(SleepPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                awake = sleepToUpdate.Awake,
                deep = sleepToUpdate.Deep,
                light = sleepToUpdate.Light,
                rem = sleepToUpdate.Rem,
                times_woken = sleepToUpdate.TimesWoken,
                total_sleep = sleepToUpdate.TotalSleep
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}