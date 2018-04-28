using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KingPim.Models;
using KingPim.Models.ModelViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KingPim.Controllers
{
    public class MediaController : Controller
    {
        private ApplicationDbContext _context;

        public MediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Media()
        {
            var viewModel = new MediaFileGroupViewModel();
            viewModel.MediaFileGroups = _context.MediaFileGroup.ToList();


            ViewBag.MediaFileGroups = new SelectList(_context.MediaFileGroup, "Id", "Name");

            return View(viewModel);
        }

        public async Task<IActionResult> CreateGroup(string name)
        {

            if (ModelState.IsValid)
            {
                MediaFileGroup mediaFileGroup = new MediaFileGroup
                {
                    Name = name,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    Published = false,
                    VersionNumber = 1,
                    ModifiedBy = User.Identity.Name,

                };

                _context.Add(mediaFileGroup);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Media));
        }

        [HttpPost]
        public async Task<IActionResult> AddFiles(ICollection<IFormFile> file, string ImageAltText, bool MainImage, string MediaType)
        {


            return RedirectToAction(nameof(Media));
        }
    }
}
