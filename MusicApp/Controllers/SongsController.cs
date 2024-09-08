using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Data.Services;
using MusicApp.Data.Static;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SongsController : Controller
    {
        private readonly ISongsService _service;

        public SongsController(ISongsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Song song)
        {
            if (!ModelState.IsValid)
            {
                return View(song);
            }
            await _service.AddAsync(song);
            return RedirectToAction(nameof(Index));
        }

        //Get: Songs/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var songDetails = await _service.GetByIdAsync(id);

            if (songDetails == null) return View("NotFound");
            return View(songDetails);
        }

        //Get: Songs/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var songDetails = await _service.GetByIdAsync(id);
            if (songDetails == null) return View("NotFound");
            return View(songDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Song song)
        {
            if (!ModelState.IsValid)
            {
                return View(song);
            }
            await _service.UpdateAsync(id, song);
            return RedirectToAction(nameof(Index));
        }

        //Get: Songs/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var songDetails = await _service.GetByIdAsync(id);
            if (songDetails == null) return View("NotFound");
            return View(songDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songDetails = await _service.GetByIdAsync(id);
            if (songDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
   
}
