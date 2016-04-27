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

        public async Task<FeedModel<WeightFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.Weight, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<WeightFeedItemModel>>(request);
        }

        public async Task<WeightPastModel> GetWeight(string uri)
        {
            if (uri.Contains(_user.Weight) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Weight + " endpoint.");
            }            
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<WeightPastModel>(request);
        }

        public async Task<WeightPastModel> UpdateWeight(WeightPastModel weightToUpdate)
        {
            var request = PrepareWeightUpdateRequest(weightToUpdate);
            return await _tokenManager.Execute<WeightPastModel>(request);
        }

        public async Task<string> CreateWeight(WeightNewModel weightToCreate)
        {
            var request = PrepareWeightCreateRequest(weightToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteWeight(string uri)
        {
            if (uri.Contains(_user.Weight) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Weight + " endpoint.");
            }             
            var request = new RestRequest(uri, Method.DELETE);
            await _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
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
            var request = new RestRequest(_user.Weight, Method.POST);

            ValidateModel(weightToCreate);

            //Add body to the request
            request.AddParameter(WeightNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = weightToCreate.Timestamp.ToUniversalTime(),
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
            var request = new RestRequest(weightToUpdate.Uri, Method.PUT);

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