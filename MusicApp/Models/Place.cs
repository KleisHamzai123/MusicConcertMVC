using MusicApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class Place : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Place Logo")]
        [Required(ErrorMessage = "Place logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Place Name")]
        [Required(ErrorMessage = "Place name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Place description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Concert> Concerts { get; set; }
    
    }
}
