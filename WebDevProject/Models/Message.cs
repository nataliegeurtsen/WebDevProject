using System.ComponentModel.DataAnnotations;

namespace WebDevProject.Models
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        [Required]
        [MaxLength(64)]
        public string Sender { get; set; }
        [Required]
        public DateTime SendTime { get; set; } = DateTime.Now;

        public Message(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }
    }
}
