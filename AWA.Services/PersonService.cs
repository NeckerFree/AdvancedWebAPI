using AWA.Domain.Interfaces;
using AWA.Models;
using AWA.Services.Interfaces;

namespace AWA.Services
{
    public class PersonService : IPersonService
    {
        public IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DTOPeople>> GetAllPeople()
        {
            //var businessEntityContact = await _unitOfWork.BusinessEntityContacts.GetAll();
            //var contactType = await _unitOfWork.ContactTypes.GetAll();
            var people = await _unitOfWork.People.GetAll();
            var emailAddress = await _unitOfWork.EmailAddresses.GetAll();
            var employees = await _unitOfWork.Employees.GetAll();
            var result = (from p in people
                          join em in employees on p.BusinessEntityId equals em.BusinessEntityId
                          join e in emailAddress on p.BusinessEntityId equals e.BusinessEntityId
                          select new DTOPeople
                          {
                              BusinessEntityId = p.BusinessEntityId,
                              Title = p.Title,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              EmailAddress = e.EmailAddress1,
                              BirthDate = em.BirthDate,
                              JobTitle = em.JobTitle
                          }
                          );
            return result;
        }



        public PagedList<DTOPeople> GetPagedPeople(PersonParameters personParameters)
        {
            var allPeople = GetAllPeople().Result.AsQueryable<DTOPeople>()
                 .Where(o => o.BirthDate.Year >= personParameters.MinYearOfBirth && o.BirthDate.Year <= personParameters.MaxYearOfBirth)
                 .OrderBy(so => so.FirstName);
            return PagedList<DTOPeople>.ToPagedList(allPeople, personParameters.PageNumber, personParameters.PageSize);
        }
    }
}
