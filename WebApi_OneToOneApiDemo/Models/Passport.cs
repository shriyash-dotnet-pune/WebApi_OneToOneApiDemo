using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_OneToOneApiDemo.Models
{
    public class Passport
    {
        [Key, ForeignKey("Person")]
        public int PersonId { get; set; }
        [Required]
        public string? PassportNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Person? Person { get; set; }

    }
}
