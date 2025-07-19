using Api.Dtos.Dependent;

namespace Api.Services;

public interface IDependentsService
{
    public Task<GetDependentDto> GetAsync(int id);
    public Task<List<GetDependentDto>> GetAllAsync();
}