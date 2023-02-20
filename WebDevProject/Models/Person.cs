using System.ComponentModel.DataAnnotations;

namespace WebDevProject.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Range(1900, 2006)]
        public int YearOfBirth { get; set; }
    }
}
