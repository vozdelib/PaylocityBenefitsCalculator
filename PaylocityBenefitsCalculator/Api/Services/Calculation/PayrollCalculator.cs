using Api.Models;

namespace Api.Services.Calculation
{
    public class PayrollCalculator : IPayrollCalculator
    {
        private readonly List<IDeductionStrategy> _deductionStrategies;

        public PayrollCalculator(
            BaseBenefitCostStrategy baseBenefitCostStrategy,
            DependentBenefitCostStrategy dependentBenefitCostStrategy,
            HighEarnerBenefitCostStrategy highEarnerBenefitCostStrategy)
        {
            _deductionStrategies = new List<IDeductionStrategy>
            {
                baseBenefitCostStrategy,
                dependentBenefitCostStrategy,
                highEarnerBenefitCostStrategy
            };
        }

        public decimal CalculateMonthlyDeduction(Employee employee)
        {
            decimal toReturn = 0;
            foreach (IDeductionStrategy strategy in _deductionStrategies)
            {
                toReturn += strategy.CalculateMonthlyCost(employee);
            }

            return toReturn;
        }
    }
}
