namespace ManagementPerson.Api.Extensions
{
    public class BaseSpecification
    {
        public string? Filter { get; set; }
        public string? Sorting { get; set; } = "name";
    }
}
