using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
