using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// Extends RestSharp.Validation.Validate to add additional validation functionality.
    /// </summary>
    public class ValidateHelper
    {
        /// <summary>
        /// Makes sure that a given value is valid (found in a list of validValues).
        /// If it is not a valid value an argument exception is thrown.
        /// This is a simple enhancement to the existing RestSharp validation functionality found 
        /// here: https://github.com/restsharp/RestSharp/tree/master/RestSharp/Validation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="validValues"></param>
        /// <param name="valueDescription"></param>
        public static void IsValueValid<T>(T value, List<T> validValues, string valueDescription)
        {
            if (validValues.Contains(value) == false)
            {
                string exMsg = "The " + valueDescription + " is not valid. Valid values are as follows: ";
                bool first = true;
                foreach (var validValue in validValues)
                {
                    if (!first)
                    {
                        exMsg += ", ";
                    }
                    exMsg += "\"" + validValue + "\"";
                    first = false;
                }
                throw new ArgumentException(exMsg);
            }
        }

        /// <summary>
        /// Validate an integer value is between the specified values (exclusive of min/max)
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Exclusive minimum value</param>
        /// <param name="max">Exclusive maximum value</param>
        public static void IsBetween(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(string.Format("Value ({0}) is not between {1} and {2}.", value, min, max));
            }
        }

        /// <summary>
        /// Validate a string length
        /// </summary>
        /// <param name="value">String to be validated</param>
        /// <param name="maxSize">Maximum length of the string</param>
        public static void IsValidLength(string value, int maxSize)
        {
            if (value == null)
                return;

            if (value.Length > maxSize)
            {
                throw new ArgumentException(string.Format("String is longer than max allowed size ({0}).", maxSize));
            }
        }
    }
}