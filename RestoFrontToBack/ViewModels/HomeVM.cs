using RestoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public PageIntro PageIntro { get; set; }
        public AboutImage AboutImage { get; set; }
        public AboutTitle AboutTitle { get; set; }
        public IEnumerable<AboutSpecial> AboutSpecials { get; set; }
        public SpecialName SpecialName { get; set; }
        public Special Specials { get; set; }
    }
}
