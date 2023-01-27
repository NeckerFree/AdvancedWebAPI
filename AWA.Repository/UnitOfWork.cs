using AWA.DataAccess;
using AWA.Domain.Interfaces;

namespace AWA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AdventureWorksContext _dbContext;

        public IPersonRepository People { get; }

        public IEmailAddressRepository EmailAddresses { get; }

        public IEmployeeRepository Employees { get; }

        public UnitOfWork(AdventureWorksContext dbContext,
                            IPersonRepository personRepository,
                            IEmailAddressRepository emailAddressRepository,
                            IEmployeeRepository employeeRepository)
        {
            this._dbContext = dbContext;
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
