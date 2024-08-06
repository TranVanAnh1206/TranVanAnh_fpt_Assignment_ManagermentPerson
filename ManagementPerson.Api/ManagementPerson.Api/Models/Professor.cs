using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.Models
{
    public class Professor : Person
    {
        [Required]
        [Range(0, 1000000000)]
        public decimal Salary { get; set; }
    }
}
