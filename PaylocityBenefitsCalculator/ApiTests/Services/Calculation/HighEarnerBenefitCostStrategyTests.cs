using Api.Models;
using Api.Services.Calculation;
using Xunit;

namespace ApiTests.Services.Calculation
{
    public class HighEarnerBenefitCostStrategyTests
    {
        [Fact]
        public void CalculateMonthlyCost_lowIncome()
        {
            // Arrange
            var strategy = new HighEarnerBenefitCostStrategy();
            var employee = new Employee
            {
                Salary = 10000, // Under the limit
            };

            // Act
            var result = strategy.CalculateMonthlyCost(employee);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateMonthlyCost_highIncome()
        {
            // Arrange
            var strategy = new HighEarnerBenefitCostStrategy();
            var employee = new Employee
            {
                Salary = 99000, // Over the limit
            };

            // Act
            var result = strategy.CalculateMonthlyCost(employee);

            // Assert
            Assert.True(result > 0);
        }
    }
}
