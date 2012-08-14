using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthGraphNet.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Implementation ripped from https://github.com/dkarzon/DropNet/blob/master/DropNet/Extensions/StringExtensions.cs.
        /// Avoids dependence on System.Web dll for HttpUtility.UrlEncode.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            value = Uri.EscapeDataString(value);

            StringBuilder builder = new StringBuilder();
            foreach (char ch in value)
            {
                if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~%".IndexOf(ch) != -1)
                {
                    builder.Append(ch);
                }
                else
                {
                    builder.Append('%' + string.Format("{0:X2}", (int)ch));
                }
            }
            return builder.ToString();
        }
    }
}