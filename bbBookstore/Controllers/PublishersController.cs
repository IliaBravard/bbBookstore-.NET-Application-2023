using bbBookstore.Data;
using bbBookstore.Data.Services;
using bbBookstore.Data.Static;
using bbBookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bbBookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PublishersController : Controller
    {
        private readonly IPublishersService _service;

        public PublishersController(IPublishersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPublishers = await _service.GetAllAsync();
            return View(allPublishers);
        }

        [AllowAnonymous]
        // Retrieve the author's details
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);

            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Country", "Year")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Country", "Year")] Publisher publisher)
        {
            publisher.Id = id;
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.UpdateAsync(id, publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);

            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
