using Api.Models;

namespace Api.Services.Calculation
{
    public class BaseBenefitCostStrategy : IDeductionStrategy
    {
        public decimal CalculateMonthlyCost(Employee employee)
        {
            return 1000.0M; //employees have a base cost of $1,000 per month (for benefits)
        }
    }
}