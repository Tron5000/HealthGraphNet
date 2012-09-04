using System;
using System.Collections.Generic;
using RestSharp;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving the records pertaining to a user. http://developer.runkeeper.com/healthgraph/records
    /// </summary>
    public class RecordsEndpoint : IRecordsEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion        
        
        #region Constructors

        public RecordsEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region IRecordsEndpoint

        public List<RecordsFeedItemModel> GetRecordsFeed()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Records;
            return _tokenManager.Execute<List<RecordsFeedItemModel>>(request);
        }

        public void GetRecordsFeedAsync(Action<List<RecordsFeedItemModel>> success, Action<HealthGraphException> failure)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Records;
            _tokenManager.ExecuteAsync<List<RecordsFeedItemModel>>(request, success, failure);
        }

        #endregion
    }
}