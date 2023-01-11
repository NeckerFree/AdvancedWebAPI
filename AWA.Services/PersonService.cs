using AWA.Domain.Interfaces;
using AWA.Models;
using AWA.Services.Interfaces;
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
                allPeople = (IOrderedQueryable<DTOPeople>)allPeople
                    .Where(o => o.BirthDate.Year >= personParameters.MinYearOfBirth && o.BirthDate.Year <= personParameters.MaxYearOfBirth);
            }
            SearchPeople(allPeople, personParameters.Name, personParameters.JobTitle);
            var allPeopleSorted = OrderPeople(allPeople, personParameters.OrderBy);
            return PagedList<DTOPeople>.ToPagedList(allPeople, personParameters.PageNumber, personParameters.PageSize);
        }

        private IOrderedQueryable<DTOPeople> OrderPeople(IQueryable<DTOPeople> allPeople, string orderBy)
        {
            IOrderedQueryable < DTOPeople > allPeopleOrdered= (IOrderedQueryable<DTOPeople>)allPeople;
            if (!allPeople.Any())
            {
                return allPeopleOrdered;
            }
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                allPeopleOrdered.OrderBy(p => p.FullName);
                return allPeopleOrdered;
            }
            var orderParameters = orderBy.Trim().Split(',');
            var propertyInfos = typeof(DTOPeople).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var orderParam in orderParameters)
            {
                if (string.IsNullOrWhiteSpace(orderParam)) continue;
                var propertyQuery = orderParam.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyQuery, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)                   continue;
                var sortingOrder = orderParam.EndsWith(" desc") ? "descending" : "ascending";
                var sortField = objectProperty.Name.ToString();
                if (!string.IsNullOrWhiteSpace(sortField))
                {
                    //var sortFieldOrder = $"{sortField} {sortingOrder}";

                    allPeopleOrdered = //orderParam.EndsWith(" desc") ? 
                        allPeopleOrdered.OrderByDescending((p => objectProperty.GetValue(p, null)));
                        //: allPeopleOrdered.OrderBy((p => objectProperty.GetValue(p, null)));
                }
            }
            
            return allPeopleOrdered;
            
        }


        private void SearchPeople(IQueryable<DTOPeople> allPeople, string? name, string? jobTitle)
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
