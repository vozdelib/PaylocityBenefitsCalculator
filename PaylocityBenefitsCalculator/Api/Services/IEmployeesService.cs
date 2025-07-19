using Api.Dtos.Employee;

namespace Api.Services;

public interface IEmployeesService
{
    public Task<GetEmployeeDto> GetAsync(int id);
    public Task<List<GetEmployeeDto>> GetAllAsync();

    public Task<GetPaycheckDto?> CalculatePaycheckAsync(int employeeId);
}