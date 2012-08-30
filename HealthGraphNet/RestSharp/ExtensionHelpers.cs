using System;
using System.Collections.Generic;
using RestSharp;

namespace HealthGraphNet.RestSharp
{
    internal static class ExtensionHelpers
    {
        #region IRestSharp Extension Methods

        /// <summary>
        /// Adds filtering parameters for the retrieval of a feed page.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="noEarlierThan"></param>
        /// <param name="noLaterThan"></param>
        /// <param name="modifiedNoEarlierThan"></param>
        /// <param name="modifiedNoLaterThan"></param>
        /// <returns></returns>
        internal static void PrepareFeedPageRequest(this IRestRequest target, string uri, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            target.Method = Method.GET;
            target.Resource = uri;
            string delimiter = "?";
            if (pageIndex.HasValue)
            {
                target.Resource += delimiter + "page={page}";
                target.AddUrlSegment("page", pageIndex.Value.ToString());
                delimiter = "&";
            }
            if (pageSize.HasValue)
            {
                target.Resource += delimiter + "pageSize={pageSize}";
                target.AddUrlSegment("pageSize", pageSize.Value.ToString());
                delimiter = "&";
            }
            if (noEarlierThan.HasValue)
            {
                target.Resource += delimiter + "noEarlierThan={noEarlierThan}";
                target.AddUrlSegment("noEarlierThan", noEarlierThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (noLaterThan.HasValue)
            {
                target.Resource += delimiter + "noLaterThan={noLaterThan}";
                target.AddUrlSegment("noLaterThan", noLaterThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (modifiedNoEarlierThan.HasValue)
            {
                target.Resource += delimiter + "modifiedNoEarlierThan={modifiedNoEarlierThan}";
                target.AddUrlSegment("modifiedNoEarlierThan", modifiedNoEarlierThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
            if (modifiedNoLaterThan.HasValue)
            {
                target.Resource += delimiter + "modifiedNoLaterThan={modifiedNoLaterThan}";
                target.AddUrlSegment("modifiedNoLaterThan", modifiedNoLaterThan.Value.ToString("yyyy-MM-dd"));
                delimiter = "&";
            }
        }

        #endregion
    }
}