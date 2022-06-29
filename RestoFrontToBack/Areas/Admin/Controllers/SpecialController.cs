using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestoFrontToBack.DAL;
using RestoFrontToBack.Extentions;
using RestoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public SpecialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Special special = _context.Specials.FirstOrDefault();
            return View(special);
        }

        public async Task< IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Special dbSpecial = await _context.Specials.FindAsync(id);
            if (dbSpecial == null) return NotFound();
            return View(dbSpecial);
        }
        
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Special dbSpecial = await _context.Specials.FindAsync(id);
            if (dbSpecial == null) return NotFound();
            Helpers.Helper.DeleteFile(_env, "assets", "images", "special", dbSpecial.ImageUrl);
            _context.Specials.Remove(dbSpecial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Special special)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!special.Photo.IsImage())
            {
               ModelState.AddModelError("Photo", "File tipi Image olmalidir");
                return View();
            }
            if (special.Photo.ImageLength(2000))
            {
                ModelState.AddModelError("Photo", "1mbdan yuksek ola bilmez");
                return View();
            }
            string fileName = await special.Photo.SaveImage(_env,"assets","images","special");

            Special newSpecial = new Special();
            newSpecial.ImageUrl = fileName;
            newSpecial.Title = special.Title;
            newSpecial.SubTitle = special.SubTitle;
            newSpecial.Text = special.Text;
            newSpecial.Price = special.Price;
            await _context.Specials.AddAsync(newSpecial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Update( int? id)
        {
            if (id == null) return NotFound();
            Special dbSpecial = await _context.Specials.FindAsync(id);
            if (dbSpecial == null) return NotFound();
            return View(dbSpecial);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Special special)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!special.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "File tipi Image olmalidir");
                return View();
            }
            if (special.Photo.ImageLength(2000))
            {
                ModelState.AddModelError("Photo", "1mbdan yuksek ola bilmez");
                return View();
            }
            string fileName = await special.Photo.SaveImage(_env, "assets", "images", "special");

            Special dbSpecial = await _context.Specials.FindAsync(id);
            dbSpecial.Title = special.Title;
            dbSpecial.SubTitle = special.SubTitle;
            dbSpecial.Text = special.Text;
            dbSpecial.Price = special.Price;
            dbSpecial.ImageUrl = fileName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
