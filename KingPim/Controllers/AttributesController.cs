using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KingPim.Models;
using KingPim.Data;
using KingPim.Models.ModelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace KingPim.Controllers
{
    [Authorize]
    public class AttributesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttributesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult Attributes()
        {
            var viewModel = new AttributeGroupViewModel();

            viewModel.AttributeGroup = _context.AttributeGroups.Include(x => x.Attribute).ToList();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Attributes(AttributeGroupViewModel postAttribute)
        {
            if (ModelState.IsValid)
            {
                var form = postAttribute.Form;
                if (form.NewGroup != null)
                {
                    var group = new AttributeGroup() { AttributeGroupName = form.NewGroup };
                    _context.AttributeGroups.Add(group);
                    _context.SaveChanges();
                }
                else if (form.SelectGroup != null && form.AttributeName != null)
                {
                    var attribute = new Models.Attribute() { AttributeGroupId = form.SelectGroup, Name = form.AttributeName, ValueType = form.ValueType };
                    _context.Attributes.Add(attribute);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction(nameof(AttributesController.Attributes), "Attributes");
        }
    }
}