namespace AWA.Services
{
    public class PersonParameters : QueryStringParameters
    {
        public uint? MinYearOfBirth { get; set; }
        public uint? MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public bool ValidYearRange => (MaxYearOfBirth == null & MinYearOfBirth == null) || (MaxYearOfBirth > MinYearOfBirth);
        public string? Name { get; internal set; } = "";
        public string? JobTitle { get; internal set; } = "";
    }
}
