using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Data.Static;
using MusicApp.Data.Services;
using MusicApp.Data.ViewModels;

namespace MusicApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ConcertsController : Controller
    {
        private readonly IConcertsService _service;

        public ConcertsController(IConcertsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allConcerts = await _service.GetAllAsync(n => n.Place);
            return View(allConcerts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allConcerts = await _service.GetAllAsync(n => n.Place);

            if (!string.IsNullOrEmpty(searchString))
            {
                

                var filteredResultNew = allConcerts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allConcerts);
        }

        //GET: Concerts/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var concertDetail = await _service.GetConcertByIdAsync(id);
            return View(concertDetail);
        }

        //GET: Concerts/Create
        public async Task<IActionResult> Create()
        {
            var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

            ViewBag.Places = new SelectList(concertDropdownsData.Places, "Id", "Name");
            ViewBag.Organisators = new SelectList(concertDropdownsData.Organisators, "Id", "FullName");
            ViewBag.Songs = new SelectList(concertDropdownsData.Songs, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewConcertVM concert)
        {
            if (!ModelState.IsValid)
            {
                var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Places = new SelectList(concertDropdownsData.Places, "Id", "Name");
                ViewBag.Organisators = new SelectList(concertDropdownsData.Organisators, "Id", "FullName");
                ViewBag.Songs = new SelectList(concertDropdownsData.Songs, "Id", "FullName");

                return View(concert);
            }

            await _service.AddNewConcertAsync(concert);
            return RedirectToAction(nameof(Index));
        }


       
        public async Task<IActionResult> Edit(int id)
        {
            var concertDetails = await _service.GetConcertByIdAsync(id);
            if (concertDetails == null) return View("NotFound");

            var response = new NewConcertVM()
            {
                Id = concertDetails.Id,
                Name = concertDetails.Name,
                Description = concertDetails.Description,
                Price = concertDetails.Price,
                StartDate = concertDetails.StartDate,
                EndDate = concertDetails.EndDate,
                ImageURL = concertDetails.ImageURL,
                ConcertCategory = concertDetails.ConcertCategory,
                PlaceId = concertDetails.PlaceId,
                OrganisatorId = concertDetails.OrganisatorId,
                SongIds = concertDetails.Songs_Concerts.Select(n => n.SongId).ToList(),
            };

            var concertDropdownsData = await _service.GetNewConcertDropdownsValues();
            ViewBag.Places = new SelectList(concertDropdownsData.Places, "Id", "Name");
            ViewBag.Organisators = new SelectList(concertDropdownsData.Organisators, "Id", "FullName");
            ViewBag.Songs = new SelectList(concertDropdownsData.Songs, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewConcertVM concert)
        {
            if (id != concert.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Places = new SelectList(concertDropdownsData.Places, "Id", "Name");
                ViewBag.Organisators = new SelectList(concertDropdownsData.Organisators, "Id", "FullName");
                ViewBag.Songs = new SelectList(concertDropdownsData.Songs, "Id", "FullName");

                return View(concert);
            }

            await _service.UpdateConcertAsync(concert);
            return RedirectToAction(nameof(Index));
        }
    }
}

