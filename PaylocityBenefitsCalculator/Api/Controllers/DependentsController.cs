using Api.Dtos;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly IDependentsService _dependentsService;
    
    public DependentsController(IDependentsService dependentsService)
    {
        _dependentsService = dependentsService;
    }

    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponseDto<GetDependentDto>>> Get(int id)
    {
        var dependent = await _dependentsService.GetAsync(id);
        if (dependent == null)
        {
            return NotFound(new ApiResponseDto<GetDependentDto>
            {
                Success = false,
                Message = $"Dependent with id {id} not found."
            });
        }

        return Ok(new ApiResponseDto<GetDependentDto>
        {
            Success = true,
            Data = dependent
        });
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponseDto<List<GetDependentDto>>>> GetAll()
    {
        var dependents = await _dependentsService.GetAllAsync();

        var result = new ApiResponseDto<List<GetDependentDto>>
        {
            Data = dependents,
            Success = true
        };

        return result;
    }
}
