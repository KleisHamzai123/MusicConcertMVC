using MusicApp.Data.Base;
using MusicApp.Data.ViewModels;
using MusicApp.Models;

namespace MusicApp.Data.Services
{
    public interface IConcertsService : IEntityBaseRepository<Concert>
    {
        Task<Concert> GetConcertByIdAsync(int id);
        Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues();
        Task AddNewConcertAsync(NewConcertVM data);
        Task UpdateConcertAsync(NewConcertVM data);
    }
}
