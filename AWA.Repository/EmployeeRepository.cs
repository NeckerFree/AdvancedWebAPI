using AWA.DataAccess;
using AWA.Domain.Interfaces;
using AWA.Models;

namespace AWA.Repository
{
    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AdventureWorksContext context) : base(context)
        {
        }
    }
    
}
