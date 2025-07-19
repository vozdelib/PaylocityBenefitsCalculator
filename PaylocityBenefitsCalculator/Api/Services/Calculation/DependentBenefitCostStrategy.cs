using Api.Models;

namespace Api.Services.Calculation
{
    public class DependentBenefitCostStrategy : IDeductionStrategy
    {
        private const decimal MONTHLY_COST_DEPENDANT = 600.0M;
        private const decimal ADDITIONAL_MONTHLY_COST_OLD_DEPENDANT = 200.0M;
        private const int OLD_DEPANDANT_AGE = 50;
        private readonly IDateTimeProvider _dateTimeProvider;

        public DependentBenefitCostStrategy(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public decimal CalculateMonthlyCost(Employee employee)
        {
            decimal agedDependentCost = 0;
            foreach (Dependent dependent in employee.Dependents)
            {
                agedDependentCost += MONTHLY_COST_DEPENDANT; //each dependent represents an additional $600 cost per month (for benefits)

                if (CalculateAge(dependent.DateOfBirth) >= OLD_DEPANDANT_AGE)
                {
                    agedDependentCost += ADDITIONAL_MONTHLY_COST_OLD_DEPENDANT; //dependents that are over 50 years old will incur an additional $200 per month            
                }
            }
            return agedDependentCost;
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = _dateTimeProvider.Today;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date.AddYears(age) > today)
            {
                age--;
            }
            return age;
        }
    }
}