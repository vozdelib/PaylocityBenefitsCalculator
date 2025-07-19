using Api.Models;

namespace Api.Persistency
{
    public class InMemoryEmployeesStore : IEmployeesStore
    {
        private readonly IDependentsStore dependentsStore;

        public InMemoryEmployeesStore(IDependentsStore dependentsStore)
        {
            this.dependentsStore = dependentsStore;
        }

        private List<Employee> _employees = new List<Employee>
        {
            new()
            {
                Id = 1,
                FirstName = "LeBron",
                LastName = "James",
                Salary = 75420.99m,
                DateOfBirth = new DateTime(1984, 12, 30)
            },
            new()
            {
                Id = 2,
                FirstName = "Ja",
                LastName = "Morant",
                Salary = 92365.22m,
                DateOfBirth = new DateTime(1999, 8, 10),
            },
            new()
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Jordan",
                Salary = 143211.12m,
                DateOfBirth = new DateTime(1963, 2, 17),
            }
        };

        public async Task<Employee?> GetAsync(int id)
        {
            var employee = _employees.FirstOrDefault(employee => id == employee.Id);
            if (employee != null)
            {
                employee.Dependents = await dependentsStore.GetAllByEmployeeIdAsync(employee.Id);
            }

            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var tasks = _employees.Select(async employee =>
            {
                employee.Dependents = await dependentsStore.GetAllByEmployeeIdAsync(employee.Id);
                return employee;
            }).ToList();

            List<Employee> toReturn = await Task.WhenAll(tasks).ContinueWith(t => t.Result.ToList());
            return toReturn;
        }
    }
}
