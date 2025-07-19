using Api.Models;
using Api.Services.Calculation;
using Xunit;

namespace ApiTests.Services.Calculation
{
    public class BaseBenefitCostStrategyTests
    {
        [Fact]
        public void CalculateMonthlyCost_ok()
        {
            // Arrange
            var strategy = new BaseBenefitCostStrategy();
            var employee = new Employee();

            // Act
            var result = strategy.CalculateMonthlyCost(employee);

            // Assert
            Assert.True(result > 0);
        }
    }
}
