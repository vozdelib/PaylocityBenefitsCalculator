using Api.Models;

namespace Api.Services.Calculation
{
    public class PayrollCalculator : IPayrollCalculator
    {
        private readonly IEnumerable<IDeductionStrategy> _deductionStrategies;

        public PayrollCalculator(IEnumerable<IDeductionStrategy> deductionStrategies)
        {
            _deductionStrategies = deductionStrategies;
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
