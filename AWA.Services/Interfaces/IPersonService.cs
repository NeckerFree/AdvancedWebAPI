namespace AWA.Services.Interfaces
{
    public  interface IPersonService
    {
        Task<IEnumerable<DTOPeople>> GetAllPeople();

        PagedList<DTOPeople> GetPagedPeople(PersonParameters personParameters);
    }
    
}
