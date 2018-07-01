using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParcelCalculator.Domain.Parcel;

namespace ParcelCalculator.AppLayer.Test
{
    [TestClass]
    public class DeliveryCostCalculatorTest
    {
        private Mock<IParcelFactory> _parcelFactoryMock;
        private Mock<IParcel> _parcelMock;
        private Mock<IValidator> _validatorMock;
        private DeliveryCostCalculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _parcelFactoryMock = new Mock<IParcelFactory>();
            _parcelMock = new Mock<IParcel>();
            _validatorMock = new Mock<IValidator>();
            _calculator = new DeliveryCostCalculator(_parcelFactoryMock.Object, _validatorMock.Object);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Pass_RejectedParcel()
        {
            _parcelMock.SetupGet(x=>x.Category).Returns(Domain.Enum.ParcelCategoryEnum.Rejected);
            _parcelMock.SetupGet(x => x.DeliveryCost).Returns(-1);
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ValidatorResult { IsValid = true });

            var result = _calculator.Calculate("500", "10", "20", "10");

            Assert.AreEqual("Rejected", result.Category);
            Assert.AreEqual(-1, result.Cost);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Pass_HeavyParcel()
        {
            _parcelMock.SetupGet(x => x.Category).Returns(Domain.Enum.ParcelCategoryEnum.Heavy);
            _parcelMock.SetupGet(x => x.DeliveryCost).Returns(600);
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ValidatorResult { IsValid = true });

            var result = _calculator.Calculate("40", "10", "20", "10");

            Assert.AreEqual("Heavy", result.Category);
            Assert.AreEqual(600, result.Cost);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Pass_SmallParcel()
        {
            _parcelMock.SetupGet(x => x.Category).Returns(Domain.Enum.ParcelCategoryEnum.Small);
            _parcelMock.SetupGet(x => x.DeliveryCost).Returns(25);
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ValidatorResult { IsValid = true });

            var result = _calculator.Calculate("9", "5", "20", "5");

            Assert.AreEqual("Small", result.Category);
            Assert.AreEqual(25, result.Cost);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Pass_MediumParcel()
        {
            _parcelMock.SetupGet(x => x.Category).Returns(Domain.Enum.ParcelCategoryEnum.Medium);
            _parcelMock.SetupGet(x => x.DeliveryCost).Returns(84);
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ValidatorResult { IsValid = true });

            var result = _calculator.Calculate("10", "10", "10", "21");

            Assert.AreEqual("Medium", result.Category);
            Assert.AreEqual(84, result.Cost);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Pass_LargeParcel()
        {
            _parcelMock.SetupGet(x => x.Category).Returns(Domain.Enum.ParcelCategoryEnum.Large);
            _parcelMock.SetupGet(x => x.DeliveryCost).Returns(75);
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ValidatorResult { IsValid = true });

            var result = _calculator.Calculate("10", "10", "10", "25");

            Assert.AreEqual("Large", result.Category);
            Assert.AreEqual(75, result.Cost);
        }

        [TestMethod]
        public void DeliveryCostCalculator_Calculate_Fail_Invalid_Height_Weight()
        {
            var validationResult = new ValidatorResult { IsValid = false, Error = "The following values are invalid: Height, Weight" };
            _parcelFactoryMock.Setup(x => x.GetParcel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_parcelMock.Object);
            _validatorMock.Setup(x => x.CheckValues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(validationResult);

            var result = _calculator.Calculate("asd", "dag", "10", "25");

            Assert.AreEqual("The following values are invalid: Height, Weight", result.Error);
        }
    }
}
