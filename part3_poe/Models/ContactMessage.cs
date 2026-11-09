using System.ComponentModel.DataAnnotations;

namespace part3_poe.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please write a message.")]
        [Display(Name = "Message")]
        public string Message { get; set; }



    }
}