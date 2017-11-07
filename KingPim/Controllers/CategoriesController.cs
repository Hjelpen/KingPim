using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KingPim.Models;
using KingPim.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using KingPim.Models.ModelViewModels;
using Microsoft.EntityFrameworkCore;

namespace KingPim.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();

            CategoryViewModel vm = new CategoryViewModel();
            vm.Categories = _context.Categories.ToList();

            return View(vm);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var categoryInfo = _context.Categories.Where(x => x.CategoryID == id).Include(y => y.SubCategories).ToList();

            ViewBag.CategoryInfo = categoryInfo;

            if (categoryInfo == null)
            {
                return NotFound();
            }

            return View(categoryInfo);
        }

        public ActionResult SubCategoryDetails(int id)
        {

            var data = _context.SubCategoryAttributeGroup
                .Include(x => x.AttributeGroup)
                .Include(y => y.SubCategory)
                .Where(x => x.SubCategoryId == id);

            

            SubCategoryViewModel subCategoryViewModel = new SubCategoryViewModel();
            List<AttributeGroup> list = new List<AttributeGroup>();
            subCategoryViewModel.SubCategoryId = id;
            {
                foreach (var item in data)
                {
                    subCategoryViewModel.Name = item.SubCategory.Name;
                    subCategoryViewModel.CreatedAt = item.SubCategory.CreatedAt;
                    subCategoryViewModel.LastModified = item.SubCategory.LastModified;
                    subCategoryViewModel.ModifiedBy = item.SubCategory.ModifiedBy;
                    subCategoryViewModel.Published = item.SubCategory.Published;
                    subCategoryViewModel.VersionNumber = item.SubCategory.VersionNumber;
                    list.Add(item.AttributeGroup);
                    subCategoryViewModel.AttributeGroups = list;
                }
            }

            ViewBag.AttributeGroups = new SelectList(_context.AttributeGroups, "AttributeGroupId", "AttributeGroupName");

            return View(subCategoryViewModel);
        }

        public IActionResult AtttributeGroupSubCategory(AttributeGroup group, int id)
        {

            SubCategoryAttributeGroup subCategoryAttributeGroup = new SubCategoryAttributeGroup();
            {
                subCategoryAttributeGroup.AttributeGroupId = group.AttributeGroupId;
                subCategoryAttributeGroup.SubCategoryId = id;
            }

            _context.Add(subCategoryAttributeGroup);
            _context.SaveChangesAsync();

            return RedirectToAction("SubCategoryDetails", new { id = id });
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Name = category.Name,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    Published = false,
                    VersionNumber = 1,
                    ModifiedBy = User.Identity.Name,           
                    
                };

                _context.Add(newCategory);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(CategoryViewModel model, int category)
        {
            if (ModelState.IsValid)
            {
                SubCategory newSubCategory = new SubCategory
                {
                    Name = model.SubCategoryName,
                    CategoryID = category,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    Published = false,
                    VersionNumber = 1,
                    ModifiedBy = User.Identity.Name,

                };

                _context.Add(newSubCategory);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("Details", new { id = category });
        }


        public ActionResult GetSubCategory(int id)
        {
            var subcategory = _context.SubCategories.
                Where(x => x.SubCategoryId == id);

            SubCategory sub = new SubCategory();
            {
                foreach (var item in subcategory)
                {
                    sub.Name = item.Name;
                    sub.LastModified = item.LastModified;
                    sub.CreatedAt = item.CreatedAt;
                    sub.ModifiedBy = item.ModifiedBy;
                    sub.VersionNumber = item.VersionNumber;
                    sub.Published = item.Published;
                }
            }

            return PartialView("_SubCategoryPartial", sub);

        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}