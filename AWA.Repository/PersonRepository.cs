using AWA.DataAccess;
using AWA.Domain.Interfaces;
using AWA.Models;

namespace AWA.Repository
{
       public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorksContext context) : base(context)
        {
        }
    }
}
