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
    /// For http://developer.runkeeper.com/healthgraph/sleep
    /// </summary>
    public class SleepEndpoint : ISleepEndpoint
    {
        #region Fields and Properties

        private Client _tokenManager;
        private UsersModel _user;

        #endregion

        #region Constructors

        public SleepEndpoint(Client tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region ISleepEndpoint

        public async Task<FeedModel<SleepFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.Sleep, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<SleepFeedItemModel>>(request);
        }

        public async Task<SleepPastModel> GetSleep(string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<SleepPastModel>(request);
        }

        public async Task<SleepPastModel> UpdateSleep(SleepPastModel sleepToUpdate)
        {
            var request = PrepareSleepUpdateRequest(sleepToUpdate);
            return await _tokenManager.Execute<SleepPastModel>(request);
        }

        public async Task<string> CreateSleep(SleepNewModel sleepToCreate)
        {
            var request = PrepareSleepCreateRequest(sleepToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteSleep(string uri)
        {
            if (uri.Contains(_user.Sleep) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Sleep + " endpoint.");
            }
            var request = new RestRequest(uri, Method.DELETE);
            request.Resource = uri;
            await _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
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
            var request = new RestRequest(_user.Sleep, Method.POST);
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
            var request = new RestRequest(sleepToUpdate.Uri, Method.PUT);

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