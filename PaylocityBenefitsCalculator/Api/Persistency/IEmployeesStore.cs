using Api.Models;

namespace Api.Persistency
{
    public interface IEmployeesStore
    {
        public Task<Employee?> GetAsync(int id);
        public Task<List<Employee>> GetAllAsync();
    }
}
