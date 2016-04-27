using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Portable;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// The built-in JsonSerializer does not have a way to ignore null properties when serializing.  It also lacks the ability to serialize to a different json 
    /// property name and it lacks the ability to automatically adjust DateTimes to Utc.  The underlying serialization procedures (SimpleJson.cs) are internal so 
    /// no options to override.  Using Json.Net as a serializer gives us more flexibility. 
    /// </summary>
    public class JsonNETSerializer : ISerializer
    {
        #region Fields and Properties

        /// <summary>
        /// Serialization of DateTime objects is done in RFC1123 format as per the following documentation. 
        /// https://groups.google.com/d/msg/healthgraph/wyHmJVuNNLQ/uCCpqbFTXxAJ
        /// </summary>
        public const string RFC1123DateTimeFormat = "R";

        #endregion

        #region Constructors

        /// <summary>
		/// Serializer that ignores null values when serializing.
		/// </summary>
		public JsonNETSerializer()
		{
			ContentType = "application/json";
		}

        #endregion

        #region ISerializer

        /// <summary>
		/// Serialize the object as JSON
		/// </summary>
		/// <param name="obj">Object to serialize</param>
		/// <returns>JSON as String</returns>
		public string Serialize(object obj)
		{
            var jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,               
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = DateFormat ?? RFC1123DateTimeFormat, DateTimeStyles = DateTimeStyles.None });
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSettings);
        }

		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string DateFormat { get; set; }

		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string RootElement { get; set; }

		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string Namespace { get; set; }

		/// <summary>
		/// Content type for serialized content
		/// </summary>
		public string ContentType { get; set; }

        #endregion

        byte[] ISerializer.Serialize(object obj)
        {
            var result = Serialize(obj);
            return Encoding.UTF8.GetBytes(result);
        }
    }
}