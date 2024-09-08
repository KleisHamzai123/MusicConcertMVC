using System.ComponentModel.DataAnnotations;
using MusicApp.Data.Enums;

namespace MusicApp.Data.ViewModels
{
    public class NewConcertVM
    {
        public int Id { get; set; }

        [Display(Name = "Concert name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Concert description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Concert poster URL")]
        [Required(ErrorMessage = "Concert poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Concert start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Concert end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Concert category is required")]
        public ConcertCategory ConcertCategory { get; set; }

        //Relationships
        [Display(Name = "Select Song(s)")]
        [Required(ErrorMessage = "Concert song(s) is required")]
        public List<int> SongIds { get; set; }

        [Display(Name = "Select a place")]
        [Required(ErrorMessage = "Concert place is required")]
        public int PlaceId { get; set; }

        [Display(Name = "Select a organisator")]
        [Required(ErrorMessage = "Concert organisator is required")]
        public int OrganisatorId { get; set; }
    }

}
