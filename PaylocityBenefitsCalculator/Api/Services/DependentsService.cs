using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Persistency;
using AutoMapper;

namespace Api.Services
{
    public class DependentsService : IDependentsService
    {
        private readonly IDependentsStore _dependentsStore;
        private readonly IMapper _mapper;

        public DependentsService(IDependentsStore dependentsStore, IMapper mapper)
        {
            _dependentsStore = dependentsStore;
            _mapper = mapper;
        }

        public async Task<List<GetDependentDto>> GetAllAsync()
        {
            var dependents = await _dependentsStore.GetAllAsync();
            return _mapper.Map<List<GetDependentDto>>(dependents);
        }

        public async Task<GetDependentDto> GetAsync(int id)
        {
            var dependent = await _dependentsStore.GetAsync(id);
            return _mapper.Map<GetDependentDto>(dependent);
        }
    }
}
