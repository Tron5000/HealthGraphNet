using System;
using System.Globalization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// Serializes a DateTime as RFC1123 Utc and deserializes into local time.
    /// </summary>
    public class AdjustToUniversalIsoDateTimeConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Assume we need to serialize as an RFC1123 formatted DateTime as a Utc to the server.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var tempDateTimeStyles = DateTimeStyles;
            var tempDateTimeFormat = DateTimeFormat;
            DateTimeStyles = DateTimeStyles.AdjustToUniversal;
            DateTimeFormat = JsonNETSerializer.RFC1123DateTimeFormat;
            base.WriteJson(writer, value, serializer);
            DateTimeStyles = tempDateTimeStyles;
            DateTimeFormat = tempDateTimeFormat;
        }

        /// <summary>
        /// If we're reading what we're reading from the Json is a DateTime, let's make sure we convert it to localtime (we're assuming the value we're 
        /// getting is in Utc and needs to be adjusted.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {                       
            var dt = base.ReadJson(reader, objectType, existingValue, serializer);
            if (dt.GetType() == typeof(DateTime))
            {
                return ((DateTime)dt).ToLocalTime();
            }
            else
            {
                return dt;
            }
        }
    }
}