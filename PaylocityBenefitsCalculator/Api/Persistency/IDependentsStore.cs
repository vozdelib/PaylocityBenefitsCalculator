using Api.Models;

namespace Api.Persistency
{
    public interface IDependentsStore
    {
        public Task<Dependent?> GetAsync(int id);
        public Task<List<Dependent>> GetAllAsync();
        public Task<List<Dependent>> GetAllByEmployeeIdAsync(int employeeId);
    }
}
