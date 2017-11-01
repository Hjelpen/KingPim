using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KingPim.Models;
using KingPim.Data;
using Microsoft.EntityFrameworkCore;

namespace KingPim.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult LoggedIn()
        {

            ViewBag.Categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(_context.SubCategories.Include(c => c.Category).ToList());

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
