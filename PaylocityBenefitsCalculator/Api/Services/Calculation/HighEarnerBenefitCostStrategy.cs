using Api.Models;

namespace Api.Services.Calculation
{
    public class HighEarnerBenefitCostStrategy : IDeductionStrategy
    {
        private const int HIGH_EARNER_LIMIT = 80000;
        private const decimal ADDITIONAL_YEARLY_PERCENTAGE_COST = 0.02M;

        public decimal CalculateMonthlyCost(Employee employee)
        {
            // employees that make more than $80,000 per year will incur an additional 2% of their yearly salary in benefits costs
            if (employee.Salary > HIGH_EARNER_LIMIT)
            {
                return employee.Salary * ADDITIONAL_YEARLY_PERCENTAGE_COST / 12;
            }
            return 0;
        }
    }
}