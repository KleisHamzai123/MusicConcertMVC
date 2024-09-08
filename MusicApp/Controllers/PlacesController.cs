using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Data.Services;
using MusicApp.Data.Static;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlacesController : Controller
    {
        private readonly IPlacesService _service;

        public PlacesController(IPlacesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPlaces = await _service.GetAllAsync();
            return View(allPlaces);
        }


        //Get: Places/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Place place)
        {
            if (!ModelState.IsValid) return View(place);
            await _service.AddAsync(place);
            return RedirectToAction(nameof(Index));
        }

        //Get: Places/Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var placeDetails = await _service.GetByIdAsync(id);
            if (placeDetails == null) return View("NotFound");
            return View(placeDetails);
        }

        //Get: Places/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var placeDetails = await _service.GetByIdAsync(id);
            if (placeDetails == null) return View("NotFound");
            return View(placeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Place place)
        {
            if (!ModelState.IsValid) return View(place);
            await _service.UpdateAsync(id, place);
            return RedirectToAction(nameof(Index));
        }

        //Get: Places/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var placeDetails = await _service.GetByIdAsync(id);
            if (placeDetails == null) return View("NotFound");
            return View(placeDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var placeDetails = await _service.GetByIdAsync(id);
            if (placeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
