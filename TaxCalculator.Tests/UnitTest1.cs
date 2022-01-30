using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Shared.Interfaces;
using TaxCalculator.Shared.Models;
using TaxCalculator.Shared.Settings;

namespace TaxCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Correct_Data_Correct_Result()
        {
            //Arange
            var input = new Income(3600, 520);
            var expected = new Taxes()
            {
                GrossIncome = 3600,
                CharitySpent = 520,
                IncomeTax = 135,
                SocialTax = 202.5
            };

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock
                .Setup(x => x.CalculateTax(input))
                .Returns(expected);

            var sut = new TaxObj(serviceMock.Object, input);

            //Act
            var actual = sut.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_Tax_Test()
        {
            //Arrange
            var incomeTaxObj = new IncomeTax(3000);
            double expected = 200;

            //Act
            var actual = incomeTaxObj.CalculateTax();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Social_Tax_Test()
        {
            //Arrange
            var socialTaxObj = new SocialTax(2000);
            double expected = 150;

            //Act
            var actual = socialTaxObj.CalculateTax();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}