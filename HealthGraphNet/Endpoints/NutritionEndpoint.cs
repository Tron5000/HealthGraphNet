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
    /// For http://developer.runkeeper.com/healthgraph/nutrition
    /// </summary>
    public class NutritionEndpoint : INutritionEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion

        #region Constructors

        public NutritionEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion 

        #region INutritionEndpoint

        public FeedModel<NutritionFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Nutrition, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<NutritionFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<NutritionFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Nutrition, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<NutritionFeedItemModel>>(request, success, failure);
        }

        public NutritionPastModel GetNutrition(string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<NutritionPastModel>(request);
        }

        public void GetNutritionAsync(Action<NutritionPastModel> success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<NutritionPastModel>(request, success, failure);
        }

        public NutritionPastModel UpdateNutrition(NutritionPastModel nutritionToUpdate)
        {
            var request = PrepareNutritionUpdateRequest(nutritionToUpdate);
            return _tokenManager.Execute<NutritionPastModel>(request);
        }

        public void UpdateNutritionAsync(Action<NutritionPastModel> success, Action<HealthGraphException> failure, NutritionPastModel nutritionToUpdate)
        {
            var request = PrepareNutritionUpdateRequest(nutritionToUpdate);
            _tokenManager.ExecuteAsync<NutritionPastModel>(request, success, failure);
        }

        public string CreateNutrition(NutritionNewModel nutritionToCreate)
        {
            var request = PrepareNutritionCreateRequest(nutritionToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public void CreateNutritionAsync(Action<string> success, Action<HealthGraphException> failure, NutritionNewModel nutritionToCreate)
        {
            var request = PrepareNutritionCreateRequest(nutritionToCreate);
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void DeleteNutrition(string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
            }
            var request = new RestRequest(Method.DELETE);
            request.Resource = uri;
            _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        public void DeleteNutritionAsync(Action success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.Nutrition) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Nutrition + " endpoint.");
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
            var request = new RestRequest(Method.POST);
            request.Resource = _user.Nutrition;

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
            var request = new RestRequest(Method.PUT);
            request.Resource = nutritionToUpdate.Uri;

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