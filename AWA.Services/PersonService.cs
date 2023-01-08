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
                              JobTitle = em.JobTitle,
                              FullName = $"{p.FirstName} {p.LastName}"
                          }
                          );
            return result;
        }



        public PagedList<DTOPeople> GetPagedPeople(PersonParameters personParameters)
        {
            var allPeople = GetAllPeople().Result.AsQueryable<DTOPeople>().OrderBy(so => so.FullName);
            if (personParameters.MinYearOfBirth != null && personParameters.MaxYearOfBirth != null)
            {
                allPeople = (IOrderedQueryable<DTOPeople>)allPeople
                    .Where(o => o.BirthDate.Year >= personParameters.MinYearOfBirth && o.BirthDate.Year <= personParameters.MaxYearOfBirth);
            }
            SearchPeople(ref allPeople, personParameters.Name, personParameters.JobTitle);
            return PagedList<DTOPeople>.ToPagedList(allPeople, personParameters.PageNumber, personParameters.PageSize);
        }

        private void SearchPeople(ref IOrderedQueryable<DTOPeople> allPeople, string? name, string? jobTitle)
        {
            if (allPeople.Any() == false) return;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(jobTitle)) return;
            allPeople = ((IOrderedQueryable<DTOPeople>)(
                from ap in allPeople
                where (
                (string.IsNullOrWhiteSpace(ap.FullName) || string.IsNullOrWhiteSpace(name) || ap.FullName.ToLower().Contains(name.Trim().ToLower())) &&
                (string.IsNullOrWhiteSpace(ap.JobTitle) || string.IsNullOrWhiteSpace(jobTitle) || ap.JobTitle.ToLower().Contains(jobTitle.Trim().ToLower())))
                select ap));

        }
    }
}
