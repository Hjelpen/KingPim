using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KingPim.Models;
using KingPim.Data;
using Microsoft.AspNetCore.Authorization;

namespace KingPim.Controllers
{ 
    [Authorize]
    public class AttributeGroupController : Controller
    {
        private ApplicationDbContext _context;

        public AttributeGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttributeGroup
        public ActionResult Index()
        {


            return View();
        }

        // GET: AttributeGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttributeGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttributeGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttributeGroup attributeGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attributeGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }



        // GET: AttributeGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttributeGroup/Edit/5
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

        // GET: AttributeGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttributeGroup/Delete/5
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