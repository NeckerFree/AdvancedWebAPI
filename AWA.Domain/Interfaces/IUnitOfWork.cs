namespace AWA.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBusinessEntityContactRepository BusinessEntityContacts { get; }
        IContactTypeRepository ContactTypes { get; }
        IPersonRepository People { get; }
        IEmailAddressRepository EmailAddresses { get; }
        IEmployeeRepository Employees { get; }
        int Complete();
    }
}
