using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Data.Services;
using MusicApp.Data.Static;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OrganisatorsController : Controller
    {
        private readonly IOrganisatorsService _service;

        public OrganisatorsController(IOrganisatorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allOrganisators = await _service.GetAllAsync();
            return View(allOrganisators);
        }

        //GET: organisators
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var organisatorDetails = await _service.GetByIdAsync(id);
            if (organisatorDetails == null) return View("NotFound");
            return View(organisatorDetails);
        }

        //GET: organisators/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Organisator organisator)
        {
            if (!ModelState.IsValid) return View(organisator);

            await _service.AddAsync(organisator);
            return RedirectToAction(nameof(Index));
        }

        //GET: organisators/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var organisatorDetails = await _service.GetByIdAsync(id);
            if (organisatorDetails == null) return View("NotFound");
            return View(organisatorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Organisator organisator)
        {
            if (!ModelState.IsValid) return View(organisator);

            if (id == organisator.Id)
            {
                await _service.UpdateAsync(id, organisator);
                return RedirectToAction(nameof(Index));
            }
            return View(organisator);
        }

        //GET: organisators/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var organisatorDetails = await _service.GetByIdAsync(id);
            if (organisatorDetails == null) return View("NotFound");
            return View(organisatorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisatorDetails = await _service.GetByIdAsync(id);
            if (organisatorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
