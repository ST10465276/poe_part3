using System.ComponentModel.DataAnnotations;

namespace part3_poe.Models
{
    public class EventCreate
    {
        [Required(ErrorMessage = "Please enter an event name.")]
        [StringLength(60, ErrorMessage = "Event name cannot be longer than 60 characters.")]
        [Display(Name = "Event name")]
        public string EventName { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please pick a date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Event date")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Please enter a location.")]
        [StringLength(70, ErrorMessage = "Location cannot be longer than 70 characters.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a distance.")]
        [Range(0.01, 999.99, ErrorMessage = "Distance must be between 0.01 and 999.99 km.")]
        [Display(Name = "Distance (km)")]
        public decimal? Distance { get; set; }

        [Required(ErrorMessage = "Please enter an event type.")]
        [StringLength(60, ErrorMessage = "Event type cannot be longer than 60 characters.")]
        [Display(Name = "Event type")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "Please enter a minimum age.")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        [Display(Name = "Minimum age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please pick a start time.")]
        [DataType(DataType.Time)]
        [Display(Name = "Start time")]
        public TimeSpan? StartTime { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Event image")]
        public IFormFile ImageFile { get; set; }

    }

    public class Update
    {
        public int? EventID { get; set; }

        [Required(ErrorMessage = "Please enter an event name.")]
        [StringLength(60, ErrorMessage = "Event name cannot be longer than 60 characters.")]
        [Display(Name = "Event name")]
        public string EventName { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please pick a date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Event date")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Please enter a location.")]
        [StringLength(70, ErrorMessage = "Location cannot be longer than 70 characters.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a distance.")]
        [Range(0.01, 999.99, ErrorMessage = "Distance must be between 0.01 and 999.99 km.")]
        [Display(Name = "Distance (km)")]
        public decimal? Distance { get; set; }

        [Required(ErrorMessage = "Please enter an event type.")]
        [StringLength(60, ErrorMessage = "Event type cannot be longer than 60 characters.")]
        [Display(Name = "Event type")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "Please enter a minimum age.")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        [Display(Name = "Minimum age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please pick a start time.")]
        [DataType(DataType.Time)]
        [Display(Name = "Start time")]
        public TimeSpan? StartTime { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Event image")]
        public IFormFile ImageFile { get; set; }

        public string ExistingImage { get; set; }
    }

}
