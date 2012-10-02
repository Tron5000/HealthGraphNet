using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IDiabetesMeasurementsEndpoint
    {
        //Get Diabetes Measurements Feed
        FeedModel<DiabetesMeasurementsFeedItemModel> GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FeedModel<DiabetesMeasurementsFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);   
        //Get Diabetes Measurement (Detailed)
        DiabetesMeasurementsPastModel GetMeasurement(string uri);
        void GetMeasurementAsync(Action<DiabetesMeasurementsPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Diabetes Measurement
        DiabetesMeasurementsPastModel UpdateMeasurement(DiabetesMeasurementsPastModel measurementToUpdate);
        void UpdateMeasurementAsync(Action<DiabetesMeasurementsPastModel> success, Action<HealthGraphException> failure, DiabetesMeasurementsPastModel measurementToUpdate);
        //Create Diabetes Measurement
        string CreateMeasurement(DiabetesMeasurementsNewModel measurementToCreate);
        void CreateMeasurementAsync(Action<string> success, Action<HealthGraphException> failure, DiabetesMeasurementsNewModel measurementToCreate);
        //Delete Diabetes Measurement
        void DeleteMeasurement(string uri);
        void DeleteMeasurementAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}