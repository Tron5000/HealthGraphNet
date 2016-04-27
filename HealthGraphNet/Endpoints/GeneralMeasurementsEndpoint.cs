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
    /// For http://developer.runkeeper.com/healthgraph/general-measurements
    /// </summary>
    public class GeneralMeasurementsEndpoint : IGeneralMeasurementsEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion        
        
        #region Constructors

        public GeneralMeasurementsEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion   

        #region IGeneralMeasurementsEndpoint

        public async Task<FeedModel<GeneralMeasurementsFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.GeneralMeasurements, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<GeneralMeasurementsFeedItemModel>>(request);
        }

        public async Task<GeneralMeasurementsPastModel> GetMeasurement(string uri)
        {
            if (uri.Contains(_user.GeneralMeasurements) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.GeneralMeasurements + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<GeneralMeasurementsPastModel>(request);
        }

        public async Task<GeneralMeasurementsPastModel> UpdateMeasurement(GeneralMeasurementsPastModel measurementToUpdate)
        {
            var request = PrepareMeasurementUpdateRequest(measurementToUpdate);
            return await _tokenManager.Execute<GeneralMeasurementsPastModel>(request);
        }

        public async Task<string> CreateMeasurement(GeneralMeasurementsNewModel measurementToCreate)
        {
            var request = PrepareMeasurementCreateRequest(measurementToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteMeasurement(string uri)
        {
            if (uri.Contains(_user.GeneralMeasurements) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.GeneralMeasurements + " endpoint.");
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
        /// <param name="measurementToValidate"></param>
        private void ValidateModel(GeneralMeasurementsModelBase measurementToValidate)
        {
            if ((measurementToValidate.Measurement.HasValue == false) || (measurementToValidate.MeasurementType.HasValue == false))
            {
                throw new ArgumentException("One of the following must be assigned a value: BloodCalcium, BloodChromium, BloodFolicAcid, BloodMagnesium, BloodPotassium, BloodSodium, BloodVitaminB12, BloodZinc, CreatineKinase, Crp, Diastolic, Ferritin, Hdl, Hscrp, Il6, Ldl, RestingHeartrate, Systolic, Testosterone, TotalCholesterol, Tsh, UricAcid, VitaminD or WhiteCellCount.");
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="measurementToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareMeasurementCreateRequest(GeneralMeasurementsNewModel measurementToCreate)
        {
            var request = new RestRequest(_user.GeneralMeasurements, Method.POST);

            ValidateModel(measurementToCreate);

            //Add body to the request
            request.AddParameter(GeneralMeasurementsNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                timestamp = measurementToCreate.Timestamp.ToUniversalTime(),
                blood_calcium = measurementToCreate.BloodCalcium,
                blood_chromium = measurementToCreate.BloodChromium,
                blood_folic_acid = measurementToCreate.BloodFolicAcid,
                blood_magnesium = measurementToCreate.BloodMagnesium,
                blood_potassium = measurementToCreate.BloodPotassium,
                blood_sodium = measurementToCreate.BloodSodium,
                blood_vitamin_b12 = measurementToCreate.BloodVitaminB12,
                blood_zinc = measurementToCreate.BloodZinc,
                creatine_kinase = measurementToCreate.CreatineKinase,
                crp = measurementToCreate.Crp,
                diastolic = measurementToCreate.Diastolic,
                ferritin = measurementToCreate.Ferritin,
                hdl = measurementToCreate.Hdl,
                hscrp = measurementToCreate.Hscrp,
                il6 = measurementToCreate.Il6,
                ldl = measurementToCreate.Ldl,
                resting_heartrate = measurementToCreate.RestingHeartrate,
                systolic = measurementToCreate.Systolic,
                testosterone = measurementToCreate.Testosterone,
                total_cholesterol = measurementToCreate.TotalCholesterol,
                tsh = measurementToCreate.Tsh,
                uric_acid = measurementToCreate.UricAcid,
                vitamin_d = measurementToCreate.VitaminD,
                white_cell_count = measurementToCreate.WhiteCellCount,
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
        private IRestRequest PrepareMeasurementUpdateRequest(GeneralMeasurementsPastModel measurementToUpdate)
        {
            var request = new RestRequest(measurementToUpdate.Uri, Method.PUT);

            ValidateModel(measurementToUpdate);

            //Add body to the request
            request.AddParameter(GeneralMeasurementsPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                blood_calcium = measurementToUpdate.BloodCalcium,
                blood_chromium = measurementToUpdate.BloodChromium,
                blood_folic_acid = measurementToUpdate.BloodFolicAcid,
                blood_magnesium = measurementToUpdate.BloodMagnesium,
                blood_potassium = measurementToUpdate.BloodPotassium,
                blood_sodium = measurementToUpdate.BloodSodium,
                blood_vitamin_b12 = measurementToUpdate.BloodVitaminB12,
                blood_zinc = measurementToUpdate.BloodZinc,
                creatine_kinase = measurementToUpdate.CreatineKinase,
                crp = measurementToUpdate.Crp,
                diastolic = measurementToUpdate.Diastolic,
                ferritin = measurementToUpdate.Ferritin,
                hdl = measurementToUpdate.Hdl,
                hscrp = measurementToUpdate.Hscrp,
                il6 = measurementToUpdate.Il6,
                ldl = measurementToUpdate.Ldl,
                resting_heartrate = measurementToUpdate.RestingHeartrate,
                systolic = measurementToUpdate.Systolic,
                testosterone = measurementToUpdate.Testosterone,
                total_cholesterol = measurementToUpdate.TotalCholesterol,
                tsh = measurementToUpdate.Tsh,
                uric_acid = measurementToUpdate.UricAcid,
                vitamin_d = measurementToUpdate.VitaminD,
                white_cell_count = measurementToUpdate.WhiteCellCount
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}