using System;
using System.Collections.Generic;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IRecordsEndpoint
    {
        Task<List<RecordsFeedItemModel>> GetRecordsFeed();
    }
}