using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Deserializers;

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
            jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal });            
            return JsonConvert.DeserializeObject<T>(response.Content, jsonSettings);
        }

        #endregion
    }
}