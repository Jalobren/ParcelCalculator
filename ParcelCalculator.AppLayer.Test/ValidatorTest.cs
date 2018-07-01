using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.AppLayer.Test
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void Validator_CheckValues_Pass()
        {
            var validator = new Validator();
            var expected = new ValidatorResult() { IsValid = true, Error = null };

            var result = validator.CheckValues("12", "1", "10", "20");

            Assert.AreEqual(expected.IsValid, result.IsValid);
        }

        [TestMethod]
        public void Validator_CheckValues_Fail_Aphanumeric()
        {
            var validator = new Validator();
            var expected = new ValidatorResult() { IsValid = false, Error = "The following values are invalid: Height" };

            var result = validator.CheckValues("12", "A1", "10", "20");

            Assert.AreEqual(expected.IsValid, result.IsValid);
            Assert.AreEqual(expected.Error, result.Error);
        }

        [TestMethod]
        public void Validator_CheckValues_Fail_HasDecimal()
        {
            var validator = new Validator();
            var expected = new ValidatorResult() { IsValid = false, Error = "The following values are invalid: Weight" };

            var result = validator.CheckValues("12.1", "1", "10", "20");

            Assert.AreEqual(expected.IsValid, result.IsValid);
            Assert.IsNotNull(expected.Error, result.Error);
        }
    }
}
