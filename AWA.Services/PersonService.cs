using AWA.Domain.Interfaces;
using AWA.Services.Interfaces;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

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
            var allPeople = GetAllPeople().Result.AsQueryable<DTOPeople>();

            if (personParameters.MinYearOfBirth != null && personParameters.MaxYearOfBirth != null)
            {
                allPeople = allPeople.Where(o => o.BirthDate.Year >= personParameters.MinYearOfBirth && o.BirthDate.Year <= personParameters.MaxYearOfBirth);
            }
            SearchPeople(ref allPeople, personParameters.Name, personParameters.JobTitle);
            OrderPeople(ref allPeople, personParameters.OrderBy);
            return PagedList<DTOPeople>.ToPagedList(allPeople, personParameters.PageNumber, personParameters.PageSize);
        }

        private void OrderPeople(ref IQueryable<DTOPeople> allPeople, string? orderBy)
        {
            if (!allPeople.Any())
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                allPeople.OrderBy(p => p.FullName);
                return;
            }
            var orderParameters = orderBy.Trim().Split(',');
            var propertyInfos = typeof(DTOPeople).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var orderParam in orderParameters)
            {
                if (string.IsNullOrWhiteSpace(orderParam)) continue;
                var propertyQuery = orderParam.Trim().Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyQuery, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null) continue;
                var sortingOrder = orderParam.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            allPeople = allPeople.OrderBy(orderQuery);
            return;
        }


        private void SearchPeople(ref IQueryable<DTOPeople> allPeople, string? name, string? jobTitle)
        {
            if (allPeople.Any() == false) return;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(jobTitle)) return;
            allPeople = ((IQueryable<DTOPeople>)(
                from ap in allPeople
                where (
                (string.IsNullOrWhiteSpace(ap.FullName) || string.IsNullOrWhiteSpace(name) || ap.FullName.ToLower().Contains(name.Trim().ToLower())) &&
                (string.IsNullOrWhiteSpace(ap.JobTitle) || string.IsNullOrWhiteSpace(jobTitle) || ap.JobTitle.ToLower().Contains(jobTitle.Trim().ToLower())))
                select ap));

        }
    }
}
