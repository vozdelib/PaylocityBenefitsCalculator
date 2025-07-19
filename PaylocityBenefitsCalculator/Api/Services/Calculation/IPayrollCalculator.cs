using Api.Models;

namespace Api.Services.Calculation
{
    public interface IPayrollCalculator
    {
        decimal CalculateMonthlyDeduction(Employee employee);
    }
}