using System;
using System.Collections.Generic;
using RestSharp.Portable;
using System.Net.Http;

namespace HealthGraphNet.RestSharp
{
    internal static class ExtensionHelpers
    {
        #region IRestSharp Extension Methods

        /// <summary>
        /// Adds filtering parameters for the retrieval of a feed page.
        /// </summary>
        /// <param name="pageIndex">Zero based index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noEarlierThan"></param>
        /// <param name="noLaterThan"></param>
        /// <param name="modifiedNoEarlierThan"></param>
        /// <param name="modifiedNoLaterThan"></param>
        /// <returns></returns>
        internal static IRestRequest CreateFeedPageRequest(string uri, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            IRestRequest target = new RestRequest(uri, Method.GET);
            if (pageIndex.HasValue)
            {
                target.AddParameter("page", pageIndex.Value);
            }
            if (pageSize.HasValue)
            {
                target.AddParameter("pageSize", pageSize.Value);
            }
            if (noEarlierThan.HasValue)
            {
                target.AddUrlSegment("noEarlierThan", noEarlierThan.Value.ToString("yyyy-MM-dd"));
            }
            if (noLaterThan.HasValue)
            {
                target.AddUrlSegment("noLaterThan", noLaterThan.Value.ToString("yyyy-MM-dd"));
            }
            if (modifiedNoEarlierThan.HasValue)
            {
                target.AddUrlSegment("modifiedNoEarlierThan", modifiedNoEarlierThan.Value.ToString("yyyy-MM-dd"));
            }
            if (modifiedNoLaterThan.HasValue)
            {
                target.AddUrlSegment("modifiedNoLaterThan", modifiedNoLaterThan.Value.ToString("yyyy-MM-dd"));
            }

            return target;
        }

        #endregion
    }
}