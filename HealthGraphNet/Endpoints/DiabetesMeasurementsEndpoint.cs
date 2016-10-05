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
    /// For http://developer.runkeeper.com/healthgraph/diabetes
    /// </summary>
    public class DiabetesMeasurementsEndpoint : IDiabetesMeasurementsEndpoint
    {
        #region Fields and Properties

        private Client _tokenManager;
        private UsersModel _user;

        #endregion    
    
        #region Constructors

        public DiabetesMeasurementsEndpoint(Client tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion 

        #region IDiabetesMeasurementsEndpoint

        public async Task< FeedModel<DiabetesMeasurementsFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.Diabetes, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<DiabetesMeasurementsFeedItemModel>>(request);
        }

        public async Task<DiabetesMeasurementsPastModel> GetMeasurement(string uri)
        {
            if (uri.Contains(_user.Diabetes) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Diabetes + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<DiabetesMeasurementsPastModel>(request);
        }

        public async Task<DiabetesMeasurementsPastModel> UpdateMeasurement(DiabetesMeasurementsPastModel measurementToUpdate)
        {
            var request = PrepareMeasurementUpdateRequest(measurementToUpdate);
            return await _tokenManager.Execute<DiabetesMeasurementsPastModel>(request);
        }

        public async Task<string> CreateMeasurement(DiabetesMeasurementsNewModel measurementToCreate)
        {
            var request = PrepareMeasurementCreateRequest(measurementToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteMeasurement(string uri)
        {
            if (uri.Contains(_user.Diabetes) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Diabetes + " endpoint.");
            }
            var request = new RestRequest(uri, Method.DELETE);
            await _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Performs validation logic prior to an update or create.
        /// </summary>
        /// <param name="measurementToValidate"></param>
        private void ValidateModel(DiabetesMeasurementsModelBase measurementToValidate)
        {
            if ((measurementToValidate.Measurement.HasValue == false) || (measurementToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: CPeptide, FastingPlasmaGlucoseTest, HemoglobinA1c, Insulin, OralGlucoseToleranceTest, RandomPlasmaGlucoseTest or Triglyceride.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="measurementToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareMeasurementCreateRequest(DiabetesMeasurementsNewModel measurementToCreate)
        {
            var request = new RestRequest(_user.Diabetes, Method.POST);

            ValidateModel(measurementToCreate);

            //Add body to the request
            request.AddParameter(DiabetesMeasurementsNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = measurementToCreate.Timestamp.ToUniversalTime(),
                c_peptide = measurementToCreate.CPeptide,
                fasting_plasma_glucose_test = measurementToCreate.FastingPlasmaGlucoseTest,
                hemoglobin_a1c = measurementToCreate.HemoglobinA1c,
                insulin = measurementToCreate.Insulin,
                oral_glucose_tolerance_test = measurementToCreate.OralGlucoseToleranceTest,
                random_plasma_glucose_test = measurementToCreate.RandomPlasmaGlucoseTest,
                triglyceride = measurementToCreate.Triglyceride,
                post_to_twitter = measurementToCreate.PostToTwitter,
                post_to_facebook = measurementToCreate.PostToFacebook
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="measurementToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareMeasurementUpdateRequest(DiabetesMeasurementsPastModel measurementToUpdate)
        {
            var request = new RestRequest(measurementToUpdate.Uri, Method.PUT);

            ValidateModel(measurementToUpdate);

            //Add body to the request
            request.AddParameter(DiabetesMeasurementsPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                c_peptide = measurementToUpdate.CPeptide,
                fasting_plasma_glucose_test = measurementToUpdate.FastingPlasmaGlucoseTest,
                hemoglobin_a1c = measurementToUpdate.HemoglobinA1c,
                insulin = measurementToUpdate.Insulin,
                oral_glucose_tolerance_test = measurementToUpdate.OralGlucoseToleranceTest,
                random_plasma_glucose_test = measurementToUpdate.RandomPlasmaGlucoseTest,
                triglyceride = measurementToUpdate.Triglyceride
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}