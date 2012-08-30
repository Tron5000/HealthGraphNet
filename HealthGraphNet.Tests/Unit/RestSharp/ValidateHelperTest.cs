using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharp;
using Moq;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Tests.Unit.RestSharp
{
    [TestFixture()]
    public class ValidateHelperTest
    {
        #region Fields, Properties and Setup

        protected readonly List<string> ValidValues = new List<string> { "orange", "apple", "peach", "berry" };

        #endregion

        #region Tests

        [Test()]
        public void IsValueValid_ValueIsInValidValueList_DoesNotThrowArgumentException()
        {
            //Arrange
            var validValue = ValidValues.First();
            //Act and Assert
            Assert.DoesNotThrow(() => { ValidateHelper.IsValueValid<string>(validValue, ValidValues, "Fruit"); });
        }

        [Test()]
        public void IsValueValid_ValueIsNotInValidValueList_ArgumentException()
        {
            //Arrange
            var invalidValue = "chicken";
            //Act and Assert
            Assert.Throws(typeof(ArgumentException), () => { ValidateHelper.IsValueValid<string>(invalidValue, ValidValues, "Fruit"); });
        }

        #endregion
    }
}