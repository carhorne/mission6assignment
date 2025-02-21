using System.ComponentModel.DataAnnotations;

namespace mission6assignment.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Category is required")] // error messages to display if form is invalid
        public int CategoryId { get; set; }
        // Navigation Property
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited is required")]
        public int Edited { get; set; } // Not required because it's a boolean
        public string? LentTo { get; set; } // Nullable (optional)
        [Required(ErrorMessage = "Copied to Plex is required")]
        public int CopiedToPlex { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; } // Nullable (optional)
    }


}

