using System;
using System.Collections.Generic;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IRecordsEndpoint
    {
        List<RecordsFeedItemModel> GetRecordsFeed();
        void GetRecordsFeedAsync(Action<List<RecordsFeedItemModel>> success, Action<HealthGraphException> failure); 
    }
}