using System.ComponentModel.DataAnnotations;

namespace PhonebookAPI.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber), MinLength(11)]
        public string Phone { get; set; }

        public string? Email { get; set; }
    }
}
