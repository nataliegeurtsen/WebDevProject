using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDevProject.Models
{
    public class Person
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid FormId { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(600)]
        public string Message { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public bool Callback { get; set; }

        [Required]
        public bool CallbackAvailableMonday { get; set; } = false;

        [Required]
        public bool CallbackAvailableTuesday { get; set; } = false;
        [Required]
        public bool CallbackAvailableWednesday { get; set; } = false;
        [Required]
        public bool CallbackAvailableThursday { get; set; } = false;
        [Required]
        public bool CallbackAvailableFriday { get; set; } = false;
    }
}
