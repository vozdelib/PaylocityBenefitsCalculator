using Api.Models;

namespace Api.Services.Calculation
{
    public class BaseBenefitCostStrategy : IDeductionStrategy
    {
        private const decimal BASE_COST = 1000.0M;

        public decimal CalculateMonthlyCost(Employee employee)
        {
            return BASE_COST; //employees have a base cost of $1,000 per month (for benefits)
        }
    }
}