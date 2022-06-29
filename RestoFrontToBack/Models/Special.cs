using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.Models
{
    public class Special
    {
        public int Id { get; set;}
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
