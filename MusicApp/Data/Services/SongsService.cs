using Microsoft.AspNetCore.Cors.Infrastructure;
using MusicApp.Data.Base;
using MusicApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Data.Services
{
    public class SongsService : EntityBaseRepository<Song>, ISongsService
    {
        public SongsService(AppDbContext context) : base(context) { }
    }
    
    
}
