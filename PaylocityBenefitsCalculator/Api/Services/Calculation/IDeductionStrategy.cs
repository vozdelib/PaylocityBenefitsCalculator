using Api.Models;

namespace Api.Services.Calculation
{
    public interface IDeductionStrategy
    {
        decimal CalculateMonthlyCost(Employee employee);
    }
}