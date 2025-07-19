using Api.Models;

namespace Api.Persistency
{
    public class InMemoryDependentsStore : IDependentsStore
    {
        private List<Dependent> _dependents = new List<Dependent>
        {
            new()
                    {
                        Id = 1,
                        FirstName = "Spouse",
                        LastName = "Morant",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1998, 3, 3),
                        EmployeeId = 2
                    },
                    new()
                    {
                        Id = 2,
                        FirstName = "Child1",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2020, 6, 23),
                        EmployeeId = 2
                    },
                    new()
                    {
                        Id = 3,
                        FirstName = "Child2",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2021, 5, 18),
                        EmployeeId = 2
                    },
                    new()
                    {
                        Id = 4,
                        FirstName = "DP",
                        LastName = "Jordan",
                        Relationship = Relationship.DomesticPartner,
                        DateOfBirth = new DateTime(1974, 1, 2),
                        EmployeeId = 3
                    }
        };

        public async Task<Dependent?> GetAsync(int id)
        {
            return _dependents.FirstOrDefault(dependent => id == dependent.Id);
        }

        public async Task<List<Dependent>> GetAllAsync()
        {
            return _dependents;
        }

        public async Task<List<Dependent>> GetAllByEmployeeIdAsync(int employeeId)
        {
            return _dependents.FindAll(dependent => employeeId == dependent.EmployeeId);
        }
    }
}
