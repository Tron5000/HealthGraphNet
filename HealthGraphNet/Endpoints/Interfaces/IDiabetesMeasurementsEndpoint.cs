using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IDiabetesMeasurementsEndpoint
    {
        //Get Diabetes Measurements Feed
        Task<FeedModel<DiabetesMeasurementsFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Diabetes Measurement (Detailed)
        Task<DiabetesMeasurementsPastModel> GetMeasurement(string uri);
        //Update Diabetes Measurement
        Task<DiabetesMeasurementsPastModel> UpdateMeasurement(DiabetesMeasurementsPastModel measurementToUpdate);
        //Create Diabetes Measurement
        Task<string> CreateMeasurement(DiabetesMeasurementsNewModel measurementToCreate);
        //Delete Diabetes Measurement
        Task DeleteMeasurement(string uri);
    }
}