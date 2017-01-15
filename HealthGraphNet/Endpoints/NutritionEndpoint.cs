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
    /// For http://developer.runkeeper.com/healthgraph/nutrition
    /// </summary>
    public class NutritionEndpoint : INutritionEndpoint
    {
        #region Fields and Properties

        private Client _tokenManager;
        private UsersModel _user;

        #endregion

        #region Constructors

        public NutritionEndpoint(Client tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region INutritionEndpoint

        public async Task<FeedModel<NutritionFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.Nutrition, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<NutritionFeedItemModel>>(request);
        }

        public async Task<NutritionPastModel> GetNutrition(string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<NutritionPastModel>(request);
        }

        public async Task<NutritionPastModel> UpdateNutrition(NutritionPastModel nutritionToUpdate)
        {
            var request = PrepareNutritionUpdateRequest(nutritionToUpdate);
            return await _tokenManager.Execute<NutritionPastModel>(request);
        }

        public async Task<string> CreateNutrition(NutritionNewModel nutritionToCreate)
        {
            var request = PrepareNutritionCreateRequest(nutritionToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteNutrition(string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
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
        /// <param name="nutritionToValidate"></param>
        private void ValidateModel(NutritionModelBase nutritionToValidate)
        {
            if ((nutritionToValidate.Measurement.HasValue == false) || (nutritionToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: Calories, Carbohydrates, Fat, Fiber, Protein, Sodium or Water.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="nutritionToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareNutritionCreateRequest(NutritionNewModel nutritionToCreate)
        {
            var request = new RestRequest(_user.Nutrition, Method.POST);

            ValidateModel(nutritionToCreate);

            //Add body to the request
            request.AddParameter(NutritionNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = nutritionToCreate.Timestamp.ToUniversalTime(),
                calories = nutritionToCreate.Calories,
                carbohydrates = nutritionToCreate.Carbohydrates,
                fat = nutritionToCreate.Fat,
                fiber = nutritionToCreate.Fiber,
                protein = nutritionToCreate.Protein,
                sodium = nutritionToCreate.Sodium,
                water = nutritionToCreate.Water,
                post_to_twitter = nutritionToCreate.PostToTwitter,
                post_to_facebook = nutritionToCreate.PostToFacebook
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="nutritionToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareNutritionUpdateRequest(NutritionPastModel nutritionToUpdate)
        {
            var request = new RestRequest(nutritionToUpdate.Uri, Method.PUT);

            ValidateModel(nutritionToUpdate);

            //Add body to the request
            request.AddParameter(NutritionPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                calories = nutritionToUpdate.Calories,
                carbohydrates = nutritionToUpdate.Carbohydrates,
                fat = nutritionToUpdate.Fat,
                fiber = nutritionToUpdate.Fiber,
                protein = nutritionToUpdate.Protein,
                sodium = nutritionToUpdate.Sodium,
                water = nutritionToUpdate.Water
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}