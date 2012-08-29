using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// The built-in JsonSerializer does not have a way to ignore null properties when serializing.  The underlying serialization procedures (SimpleJson.cs) are 
    /// sealed so no options to override.  Using Json.Net as a serializer (has ignoring of null values build in).
    /// </summary>
    public class JsonIgnoreNullSerializer : ISerializer
    {
        #region Constructors

		/// <summary>
		/// Serializer that ignores null values when serializing.
		/// </summary>
		public JsonIgnoreNullSerializer()
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
            //return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';
                    serializer.Serialize(jsonTextWriter, obj);
                    var result = stringWriter.ToString();
                    return result;
                }
            }        
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
    }
}