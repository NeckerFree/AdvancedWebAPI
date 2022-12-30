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
            var businessEntityContact = await _unitOfWork.BusinessEntityContacts.GetAll();
            var contactType = await _unitOfWork.ContactTypes.GetAll();
            var people = await _unitOfWork.People.GetAll();
            var emailAddress = await _unitOfWork.EmailAddresses.GetAll();
            var result = (from b in businessEntityContact
                          join c in contactType on b.ContactTypeId equals c.ContactTypeId
                          join p in people on b.PersonId equals p.BusinessEntityId
                          join e in emailAddress on p.BusinessEntityId equals e.BusinessEntityId
                          select new DTOPeople { BusinessEntityId = b.BusinessEntityId, Name = c.Name, Title = p.Title, FirstName = p.FirstName, LastName = p.LastName, EmailAddress = e.EmailAddress1 }
                          );
            return result;
        }

        //public PagedList<DTOPeople> GetPagedPeople(PersonParameters personParameters)
        //{
        //    var allPeople = GetAllPeople().Result.ToList<DTOPeople>();
        //    int totalRecords = allPeople.Count();
        //    //var items = allPeople.Skip((personParameters.PageNumber - 1) * personParameters.PageSize).Take(personParameters.PageSize).ToList();
        //    var result = new PagedList<DTOPeople>(allPeople, totalRecords, personParameters.PageNumber, personParameters.PageSize);
        //    return result.top;

        //}
        public PagedList<DTOPeople> GetPagedPeople(PersonParameters personParameters)
        {
            var allPeople = GetAllPeople().Result.AsQueryable<DTOPeople>();
            return PagedList<DTOPeople>.ToPagedList(allPeople, personParameters.PageNumber, personParameters.PageSize);
        }
    }
}
