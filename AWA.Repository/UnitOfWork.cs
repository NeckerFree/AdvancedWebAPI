using AWA.DataAccess;
using AWA.Domain.Interfaces;

namespace AWA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AdventureWorksContext _dbContext;

        //public IBusinessEntityContactRepository BusinessEntityContacts { get; }

        //public IContactTypeRepository ContactTypes { get; }

        public IPersonRepository People { get; }

        public IEmailAddressRepository EmailAddresses { get; }

        public IEmployeeRepository Employees { get; }

        public UnitOfWork(AdventureWorksContext dbContext,
                            //IBusinessEntityContactRepository businessEntityContactRepository,
                            //IContactTypeRepository contactTypeRepository,
                            IPersonRepository personRepository,
                            IEmailAddressRepository emailAddressRepository,
                            IEmployeeRepository employeeRepository)
        {
            this._dbContext = dbContext;
            //this.BusinessEntityContacts = businessEntityContactRepository;
            //this.ContactTypes = contactTypeRepository;
            this.People = personRepository;
            this.EmailAddresses = emailAddressRepository;
            this.Employees = employeeRepository;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }

        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
