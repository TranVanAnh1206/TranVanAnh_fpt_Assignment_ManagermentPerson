using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementPerson.Api.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
