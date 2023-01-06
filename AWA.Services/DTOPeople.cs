namespace AWA.Services
{
    public class DTOPeople
    {
        public int BusinessEntityId { get; internal set; }
        public string? Name { get; internal set; }
        public string? Title { get; internal set; }
        public string? FirstName { get; internal set; }
        public string? LastName { get; internal set; }
        public string? EmailAddress { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public string? JobTitle { get; internal set; }
    }
}