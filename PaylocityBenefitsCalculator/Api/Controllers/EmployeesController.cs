using Api.Dtos;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponseDto<GetEmployeeDto>>> Get(int id)
    {
        var employee = await _employeesService.GetAsync(id);
        if (employee == null)
        {
            return NotFound(new ApiResponseDto<GetEmployeeDto>
            {
                Success = false,
                Message = $"Employee with id {id} not found."
            });
        }

        return Ok(new ApiResponseDto<GetEmployeeDto>
        {
            Success = true,
            Data = employee
        });
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponseDto<List<GetEmployeeDto>>>> GetAll()
    {
        var employees = await _employeesService.GetAllAsync();

        var result = new ApiResponseDto<List<GetEmployeeDto>>
        {
            Data = employees,
            Success = true
        };

        return result;
    }


    [SwaggerOperation(Summary = "Get paycheck for an employee")]
    [HttpGet("{id}/paycheck")]    
    public async Task<ActionResult<ApiResponseDto<GetPaycheckDto>>> GetPaycheck(int id)
    {
        var paycheck = await _employeesService.CalculatePaycheckAsync(id);
        if (paycheck == null)
        {
            return NotFound(new ApiResponseDto<GetPaycheckDto>
            {
                Success = false,
                Message = $"Employee with id {id} not found."
            });
        }

        return Ok(new ApiResponseDto<GetPaycheckDto>
        {
            Success = true,
            Data = paycheck
        });
    }
}
