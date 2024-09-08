using MusicApp.Models;

namespace MusicApp.Data.ViewModels
{
    public class NewConcertDropdownsVM
    {
        public NewConcertDropdownsVM()
        {
            Organisators = new List<Organisator>();
            Places = new List<Place>();
            Songs = new List<Song>();
        }

        public List<Organisator> Organisators { get; set; }
        public List<Place> Places { get; set; }
        public List<Song> Songs { get; set; }
    }
}

