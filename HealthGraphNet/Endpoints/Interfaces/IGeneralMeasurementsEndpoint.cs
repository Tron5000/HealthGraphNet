using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IGeneralMeasurementsEndpoint
    {
        //Get General Measurements Feed
        Task<FeedModel<GeneralMeasurementsFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get General Measurement (Detailed)
        Task<GeneralMeasurementsPastModel> GetMeasurement(string uri);
        //Update General Measurement (Detailed)
        Task<GeneralMeasurementsPastModel> UpdateMeasurement(GeneralMeasurementsPastModel measurementToUpdate);
        //Create General Measurement
        Task<string> CreateMeasurement(GeneralMeasurementsNewModel measurementToCreate);
        //Delete Measurement
        Task DeleteMeasurement(string uri);
    }
}