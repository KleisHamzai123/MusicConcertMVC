using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicApp.Data.Base;
using MusicApp.Data.Enums;
using System;

namespace MusicApp.Models
{
    public class Concert:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ConcertCategory ConcertCategory { get; set; }

        //Relationships
        public List<Song_Concert> Songs_Concerts { get; set; }

        //Place
        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        //Organisator
        public int OrganisatorId { get; set; }
        [ForeignKey("OrganisatorId")]
        public Organisator Organisator { get; set; }
    }
}

