using System;
using System.IO;
using System.Reflection;

namespace HealthGraphNet.Tests
{
    /// <summary>
    /// Retrieving data from embedded resources
    /// </summary>
    class Resource
    {
        public const string UserInfoJson = "userinfo.json";

        public static Stream GetStream(string resourceName)
        {
            var asm = typeof(Resource).GetTypeInfo().Assembly;
            foreach (var name in asm.GetManifestResourceNames())
            {
                if (name.Contains(resourceName))
                    return asm.GetManifestResourceStream(name);
            }

            return null;
        }

        public static string GetText(string resourceName)
        {
            using (var stream = GetStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
