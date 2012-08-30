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
    /// For http://developer.runkeeper.com/healthgraph/weight
    /// </summary>
    public class WeightEndpoint : IWeightEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion
    
        #region Constructors

        public WeightEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion    
    
        #region IWeightEndpoint

        public FeedModel<WeightFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Weight, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<WeightFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<WeightFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Weight, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<WeightFeedItemModel>>(request, success, failure);
        }

        public WeightPastModel GetWeight(string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<WeightPastModel>(request);
        }

        public void GetWeightAsync(Action<WeightPastModel> success, Action<HealthGraphException> failure, string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<WeightPastModel>(request, success, failure);
        }

        public WeightPastModel UpdateWeight(WeightPastModel weightToUpdate)
        {
            var request = PrepareWeightUpdateRequest(weightToUpdate);
            return _tokenManager.Execute<WeightPastModel>(request);
        }

        public void UpdateWeightAsync(Action<WeightPastModel> success, Action<HealthGraphException> failure, WeightPastModel weightToUpdate)
        {
            var request = PrepareWeightUpdateRequest(weightToUpdate);
            _tokenManager.ExecuteAsync<WeightPastModel>(request, success, failure);
        }

        public string CreateWeight(WeightNewModel weightToCreate)
        {
            var request = PrepareWeightCreateRequest(weightToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public void CreateWeightAsync(Action<string> success, Action<HealthGraphException> failure, WeightNewModel weightToCreate)
        {
            var request = PrepareWeightCreateRequest(weightToCreate);
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void DeleteWeight(string uri)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.ExecuteDelete(request);
        }

        public void DeleteWeightAsync(Action success, Action<HealthGraphException> failure, string uri)
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
        /// <param name="weightToValidate"></param>
        private void ValidateModel(WeightModelBase weightToValidate)
        {
            if ((weightToValidate.Measurement.HasValue == false) || (weightToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: Bmi, FatPercent, FreeMass, MassWeight or Weight.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="weightToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareWeightCreateRequest(WeightNewModel weightToCreate)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = _user.Weight;

            ValidateModel(weightToCreate);

            //Add body to the request
            request.AddParameter(WeightNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = weightToCreate.Timestamp,
                bmi = weightToCreate.Bmi,
                fat_percent = weightToCreate.FatPercent,
                free_mass = weightToCreate.FreeMass,
                mass_weight = weightToCreate.MassWeight,
                weight = weightToCreate.Weight,
                post_to_twitter = weightToCreate.PostToTwitter,
                post_to_facebook = weightToCreate.PostToFacebook
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="weightToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareWeightUpdateRequest(WeightPastModel weightToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = weightToUpdate.Uri;

            ValidateModel(weightToUpdate);

            //Add body to the request
            request.AddParameter(WeightPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                bmi = weightToUpdate.Bmi,
                fat_percent = weightToUpdate.FatPercent,
                free_mass = weightToUpdate.FreeMass,
                mass_weight = weightToUpdate.MassWeight,
                weight = weightToUpdate.Weight
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}