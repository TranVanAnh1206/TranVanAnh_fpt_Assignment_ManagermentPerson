using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class ProfessorCreateUpdateViewModel : PersonCreateViewModel
    {
        [Required]
        [Range(0, 1000000000)]
        public decimal Salary { get; set; }
    }
}
