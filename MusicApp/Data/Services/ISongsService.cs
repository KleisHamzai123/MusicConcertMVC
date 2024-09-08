using MusicApp.Data.Base;
using MusicApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MusicApp.Data.Services
{
    public interface ISongsService : IEntityBaseRepository<Song>
    {
    }
    
}
