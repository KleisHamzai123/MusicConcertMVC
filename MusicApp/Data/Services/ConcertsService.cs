using Microsoft.EntityFrameworkCore;
using MusicApp.Data.Base;
using MusicApp.Data.ViewModels;
using MusicApp.Models;

namespace MusicApp.Data.Services
{
    public class ConcertsService : EntityBaseRepository<Concert>, IConcertsService
    {
        private readonly AppDbContext _context;
        public ConcertsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewConcertAsync(NewConcertVM data)
        {
            var newConcert = new Concert()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                PlaceId = data.PlaceId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ConcertCategory = data.ConcertCategory,
                OrganisatorId = data.OrganisatorId
            };
            await _context.Concerts.AddAsync(newConcert);
            await _context.SaveChangesAsync();

            //Add 
            foreach (var songId in data.SongIds)
            {
                var newSongConcert = new Song_Concert()
                {
                    ConcertId = newConcert.Id,
                    SongId = songId
                };
                await _context.Songs_Concerts.AddAsync(newSongConcert);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Concert> GetConcertByIdAsync(int id)
        {
            var concertDetails = await _context.Concerts
                .Include(c => c.Place)
                .Include(p => p.Organisator)
                .Include(am => am.Songs_Concerts).ThenInclude(a => a.Song)
                .FirstOrDefaultAsync(n => n.Id == id);

            return concertDetails;
        }

        public async Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues()
        {
            var response = new NewConcertDropdownsVM()
            {
                Songs = await _context.Songs.OrderBy(n => n.FullName).ToListAsync(),
                Places = await _context.Places.OrderBy(n => n.Name).ToListAsync(),
                Organisators = await _context.Organisators.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateConcertAsync(NewConcertVM data)
        {
            var dbConcert = await _context.Concerts.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbConcert != null)
            {
                dbConcert.Name = data.Name;
                dbConcert.Description = data.Description;
                dbConcert.Price = data.Price;
                dbConcert.ImageURL = data.ImageURL;
                dbConcert.PlaceId = data.PlaceId;
                dbConcert.StartDate = data.StartDate;
                dbConcert.EndDate = data.EndDate;
                dbConcert.ConcertCategory = data.ConcertCategory;
                dbConcert.OrganisatorId = data.OrganisatorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing songs
            var existingSongsDb = _context.Songs_Concerts.Where(n => n.ConcertId == data.Id).ToList();
            _context.Songs_Concerts.RemoveRange(existingSongsDb);
            await _context.SaveChangesAsync();

            //Add 
            foreach (var songId in data.SongIds)
            {
                var newSongConcert = new Song_Concert()
                {
                    ConcertId = data.Id,
                    SongId = songId
                };
                await _context.Songs_Concerts.AddAsync(newSongConcert);
            }
            await _context.SaveChangesAsync();
        }
    }
}
    

