using System.ComponentModel.DataAnnotations;

namespace part3_poe.Models
{
    public class ProfileUpdate
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150, ErrorMessage = "Email cannot be longer than 150 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
