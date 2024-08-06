using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class PersonCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public int AddressId { get; set; }
    }
}
