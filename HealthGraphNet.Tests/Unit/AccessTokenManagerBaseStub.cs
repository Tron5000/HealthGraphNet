using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using HealthGraphNet;

namespace HealthGraphNet.Tests.Unit
{
    /// <summary>
    /// Stubbing out the actual restsharp request execution. Overriding internals in a different assembly thanks to the InternalsVisibleTo attribute.
    /// </summary>
    public abstract class AccessTokenManagerBaseStub : AccessTokenManagerBase
    {
        #region IRequest Execution

        internal override T Execute<T>(IRestRequest request, string baseUrl = null)
        {
            return new T();
        }

        internal override void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<HealthGraphException> failure, string baseUrl = null)
        {
        }

        #endregion      
    }
}