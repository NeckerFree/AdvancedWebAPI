using AWA.DataAccess;
using AWA.Domain.Interfaces;
using AWA.Models;

namespace AWA.Repository
{
    public class EmailAddressRepository : GenericRepository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(AdventureWorksContext context) : base(context)
        {
        }
    }
}
