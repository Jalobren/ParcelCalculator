using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelCalculator.Domain.Parcel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.AppLayer.Test
{
    [TestClass]
    public class ParcelFactoryTest
    {
        [TestMethod]
        public void ParcelFactory_GetParcel_Rejected()
        {
            var parcelFactory = new ParcelFactory();

            var result = parcelFactory.GetParcel(51, 10, 10, 10);

            Assert.IsInstanceOfType(result, typeof(RejectParcel));
        }

        [TestMethod]
        public void ParcelFactory_GetParcel_Heavy()
        {
            var parcelFactory = new ParcelFactory();

            var result = parcelFactory.GetParcel(41, 10, 20, 10);

            Assert.IsInstanceOfType(result, typeof(HeavyParcel));
        }

        [TestMethod]
        public void ParcelFactory_GetParcel_Medium()
        {
            var parcelFactory = new ParcelFactory();

            var result = parcelFactory.GetParcel(9, 10, 10, 23);

            Assert.IsInstanceOfType(result, typeof(MediumParcel));
        }

        [TestMethod]
        public void ParcelFactory_GetParcel_Small()
        {
            var parcelFactory = new ParcelFactory();

            var result = parcelFactory.GetParcel(10, 1, 3, 5);

            Assert.IsInstanceOfType(result, typeof(SmallParcel));
        }

        [TestMethod]
        public void ParcelFactory_GetParcel_Large()
        {
            var parcelFactory = new ParcelFactory();

            var result = parcelFactory.GetParcel(8, 100, 80, 120);

            Assert.IsInstanceOfType(result, typeof(LargeParcel));
        }
    }
}
