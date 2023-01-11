namespace AWA.Services
{
    public class PersonParameters : QueryStringParameters
    {
        public PersonParameters()
        {
            OrderBy= "FullName";
        }
        public uint? MinYearOfBirth { get; set; }
        public uint? MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public bool ValidYearRange => (MaxYearOfBirth == null & MinYearOfBirth == null) || (MaxYearOfBirth > MinYearOfBirth);
        public string? Name { get; internal set; } = "";
        public string? JobTitle { get; internal set; } = "";
        public string OrderBy { get; set; }
    }
}
