using Api.Models;
using Api.Services.Calculation;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.Services.Calculation
{
    public class PayrollCalculatorTests
    {
        [Fact]
        public void CalculateMonthlyDeduction_ok()
        {
            // Arrange
            var employee = new Employee();

            var strategy1 = new Mock<IDeductionStrategy>();
            var strategy2 = new Mock<IDeductionStrategy>();
            var strategy3 = new Mock<IDeductionStrategy>();

            strategy1.Setup(s => s.CalculateMonthlyCost(employee)).Returns(1m);
            strategy2.Setup(s => s.CalculateMonthlyCost(employee)).Returns(10m);
            strategy3.Setup(s => s.CalculateMonthlyCost(employee)).Returns(100m);

            var strategies = new List<IDeductionStrategy>
            {
                strategy1.Object,
                strategy2.Object,
                strategy3.Object
            };

            var calculator = new PayrollCalculator(strategies);


            // Act
            var result = calculator.CalculateMonthlyDeduction(employee);

            // Assert
            Assert.Equal(111m, result);
        }
    }
}