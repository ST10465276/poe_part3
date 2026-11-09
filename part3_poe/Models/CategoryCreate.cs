using System.ComponentModel.DataAnnotations;

namespace part_2API.Models
{
    public class CategoryCreate
    {
        [Required(ErrorMessage = "Please enter a category name.")]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters.")]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}