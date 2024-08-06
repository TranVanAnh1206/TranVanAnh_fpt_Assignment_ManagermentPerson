using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class ProfessorViewModel
    {
        [Required]
        [Range(0, 1000000000)]
        public decimal Salary { get; set; }
    }
}
