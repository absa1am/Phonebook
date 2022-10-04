using System.ComponentModel.DataAnnotations;

namespace PhonebookApp.Models;

public class Contact
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
}