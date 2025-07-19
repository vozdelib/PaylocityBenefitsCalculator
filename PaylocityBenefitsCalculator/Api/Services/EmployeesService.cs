using Api.Dtos.Employee;
using Api.Models;
using Api.Persistency;
using Api.Services.Calculation;
using AutoMapper;

namespace Api.Services
{
    public class EmployeesService : IEmployeesService
    {
        private const int NR_OF_PAYCHECKS_PER_YEAR = 26;

        private readonly IEmployeesStore _employeesStore;
        private readonly IMapper _mapper;
        private readonly IPayrollCalculator _payrollCalculator;

        public EmployeesService(IEmployeesStore employeesStore, IMapper mapper, IPayrollCalculator payrollCalculator)
        {
            _employeesStore = employeesStore;
            _mapper = mapper;
            _payrollCalculator = payrollCalculator;
        }

        public async Task<List<GetEmployeeDto>> GetAllAsync()
        {
            var employees = await _employeesStore.GetAllAsync();
            return _mapper.Map<List<GetEmployeeDto>>(employees);
        }
        public async Task<GetEmployeeDto> GetAsync(int id)
        {
            var employee = await _employeesStore.GetAsync(id);
            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task<GetPaycheckDto?> CalculatePaycheckAsync(int employeeId)
        {
            var employee = await _employeesStore.GetAsync(employeeId);
            if (employee == null)
            {
                return null;
            }

            decimal grossPay = employee.Salary / NR_OF_PAYCHECKS_PER_YEAR;
            decimal deduction = _payrollCalculator.CalculateMonthlyDeduction(employee) * 12 / NR_OF_PAYCHECKS_PER_YEAR;
            decimal netPay = grossPay - deduction;

            return new GetPaycheckDto
            {
                EmployeeId = employee.Id,
                GrossPay = grossPay,
                Deductions = deduction,
                NetPay = netPay
            };
        }
    }
}
