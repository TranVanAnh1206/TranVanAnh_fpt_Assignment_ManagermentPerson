using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class AddressCreateUpdateViewModel
    {
        public int AddressId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
