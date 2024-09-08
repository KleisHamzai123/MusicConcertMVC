using MusicApp.Data.Base;
using MusicApp.Models;

namespace MusicApp.Data.Services
{
    public class OrganisatorsService : EntityBaseRepository<Organisator>, IOrganisatorsService
    {
        public OrganisatorsService(AppDbContext context) : base(context)
        {
        }

    }
}
