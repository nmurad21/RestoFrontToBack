﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.Extentions
{
    public static class Extention
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool ImageLength(this IFormFile file, int kb)
        {
             return file.Length / 1024 > kb;
        }
        public static async Task <string> SaveImage(this IFormFile file, IWebHostEnvironment env, string folder, string images, string special)
        {
            string path = env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string result = Path.Combine(path, folder,images,special, fileName);
            using (FileStream fileStream = new FileStream(result, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
