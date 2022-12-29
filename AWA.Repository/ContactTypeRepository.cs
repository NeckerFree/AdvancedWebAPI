using AWA.DataAccess;
using AWA.Domain.Interfaces;
using AWA.Models;

namespace AWA.Repository
{
    public class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(AdventureWorksContext context) : base(context)
        {
        }
    }
}
