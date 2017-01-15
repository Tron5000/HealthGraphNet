using System;
using System.Collections.Generic;
using RestSharp.Portable;
using HealthGraphNet.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving the records pertaining to a user. http://developer.runkeeper.com/healthgraph/records
    /// </summary>
    public class RecordsEndpoint : IRecordsEndpoint
    {
        #region Fields and Properties

        private Client _tokenManager;
        private UsersModel _user;

        #endregion        
        
        #region Constructors

        public RecordsEndpoint(Client tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region IRecordsEndpoint

        public async Task<List<RecordsFeedItemModel>> GetRecordsFeed()
        {
            var request = new RestRequest(_user.Records) { Method = Method.GET };
            return await _tokenManager.Execute<List<RecordsFeedItemModel>>(request);
        }


        #endregion
    }
}