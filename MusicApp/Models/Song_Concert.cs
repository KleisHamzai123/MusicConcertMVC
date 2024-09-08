using MusicApp.Data.Base;

namespace MusicApp.Models
{
    public class Song_Concert 
    {
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
