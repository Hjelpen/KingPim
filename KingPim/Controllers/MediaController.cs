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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;

namespace KingPim.Controllers
{
    public class MediaController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public MediaController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> AddFiles(ICollection<IFormFile> file, string ImageAltText, bool MainImage, MediaType mediaType, int id)
        {
          
                foreach (var formFile in file)
                {
                    var fileType = formFile.ContentType.Split("/")[1];

                    var fileName = formFile.FileName;

                    switch (fileType)
                    {
                        case "jpg":
                        case "jpeg":
                            fileType = ".jpg";
                            break;

                        case "png":
                            fileType = ".png";
                            break;

                        case "text":
                        case "plain":
                            fileType = ".txt";
                            break;

                        case "mp4":
                            fileType = ".mp4";
                            break;

                        case "pdf":
                            fileType = ".pdf";
                            break;

                        default:
                            fileType = "";
                            break;
                    }

                var fileGuid = Guid.NewGuid();
                var filePath = _appEnvironment.WebRootPath + "/uploads/" + fileGuid + fileType;
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {

                        await formFile.CopyToAsync(stream);

                        var mediaFile = new MediaFile()
                        {
                            MediaFileGroupId = id,
                            Name = fileName,
                            MediaType = mediaType,
                            Type = fileType.Substring(1),
                            GuidName = fileGuid.ToString(),
                            AltText = ImageAltText,
                            MainFile = MainImage
                        };

                        _context.MediaFiles.Add(mediaFile);
                        _context.SaveChanges();

                    }
                }
            }

            return RedirectToAction("Media", "Media");
        }
    }
}
