using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<PageIntro> PageIntros { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<AboutTitle> AboutTitles { get; set; }
        public DbSet<AboutSpecial> AboutSpecials { get; set; }
        public DbSet<SpecialName> SpecialNames { get; set; }
        public DbSet<Special> Specials { get; set; }
    }
}
