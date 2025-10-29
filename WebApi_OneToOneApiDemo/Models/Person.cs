using System.ComponentModel.DataAnnotations;

namespace WebApi_OneToOneApiDemo.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string? Name { get; set; }

        public Passport Passport { get; set; }

    }
}
