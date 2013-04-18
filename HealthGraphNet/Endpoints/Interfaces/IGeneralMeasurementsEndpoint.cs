using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IGeneralMeasurementsEndpoint
    {
        //Get General Measurements Feed
        FeedModel<GeneralMeasurementsFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<GeneralMeasurementsFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);   
        //Get General Measurement (Detailed)
        GeneralMeasurementsPastModel GetMeasurement(string uri);
        void GetMeasurementAsync(Action<GeneralMeasurementsPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update General Measurement (Detailed)
        GeneralMeasurementsPastModel UpdateMeasurement(GeneralMeasurementsPastModel measurementToUpdate);
        void UpdateMeasurementAsync(Action<GeneralMeasurementsPastModel> success, Action<HealthGraphException> failure, GeneralMeasurementsPastModel measurementToUpdate);
        //Create General Measurement
        string CreateMeasurement(GeneralMeasurementsNewModel measurementToCreate);
        void CreateMeasurement(Action<string> success, Action<HealthGraphException> failure, GeneralMeasurementsNewModel measurementToCreate);
        //Delete Measurement
        void DeleteMeasurement(string uri);
        void DeleteMeasurementAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}