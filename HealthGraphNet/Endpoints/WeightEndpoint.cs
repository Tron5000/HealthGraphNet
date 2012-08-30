using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet
{
    /// <summary>
    /// For http://developer.runkeeper.com/healthgraph/weight
    /// </summary>
    public class WeightEndpoint : IWeightEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion
    
        #region Constructors

        public WeightEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion    
    
        #region IWeightEndpoint

        public FeedModel<WeightFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Weight, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<WeightFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<WeightFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Weight, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<WeightFeedItemModel>>(request, success, failure);
        }

        #endregion
    }
}
