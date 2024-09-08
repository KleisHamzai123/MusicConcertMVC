using MusicApp.Data.Base;
using MusicApp.Models;

namespace MusicApp.Data.Services
{
    public class PlacesService : EntityBaseRepository<Place>, IPlacesService
    {
        public PlacesService(AppDbContext context) : base(context)
        { }
    }
}



