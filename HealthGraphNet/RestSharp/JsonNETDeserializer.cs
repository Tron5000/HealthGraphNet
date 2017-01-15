using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// The built in RestSharp de-serializer didn't convert Utc to localtime automatically.
    /// Decided to use Newtonsoft for de-serialization.
    /// </summary>
    public class JsonNETDeserializer : IDeserializer
    {
        #region IDeserializer

        /// <summary>
        /// Unused for Json deserializer.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Unused for Json deserializer.
        /// </summary>
        public string RootElement { get; set; }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            var jsonSettings = new JsonSerializerSettings
            {                
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Ignore
            };
            var responseAsString = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
            return JsonConvert.DeserializeObject<T>(responseAsString, jsonSettings);
        }

        #endregion
    }
}