using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Validation;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// Extends RestSharp.Validation.Validate to add additional validation functionality.
    /// </summary>
    public class ValidateHelper : Validate
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
    }
}