using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MusicApp.Data.Base;


namespace MusicApp.Models
{
    public class Song : IEntityBase
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Song Picture")]
        [Required(ErrorMessage = "Song Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Song_Concert> Songs_Concerts { get; set; }

    }
}

