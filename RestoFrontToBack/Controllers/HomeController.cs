using Microsoft.AspNetCore.Mvc;
using RestoFrontToBack.DAL;
using RestoFrontToBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _context.Sliders.ToList();
            homeVM.PageIntro = _context.PageIntros.FirstOrDefault();
            homeVM.AboutImage = _context.AboutImages.FirstOrDefault();
            homeVM.AboutTitle = _context.AboutTitles.FirstOrDefault();
            homeVM.AboutSpecials = _context.AboutSpecials.ToList();
            homeVM.SpecialName = _context.SpecialNames.FirstOrDefault();
            homeVM.Specials = _context.Specials.FirstOrDefault();
            return View(homeVM);
        }
    }
}
