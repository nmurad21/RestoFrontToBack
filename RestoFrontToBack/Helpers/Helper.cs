using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestoFrontToBack.Helpers
{
    public class Helper
    {
        public static void DeleteFile(IWebHostEnvironment env,string folder, string images, string folderName, string fileName)
        {
            string path = env.WebRootPath;
            string resultPath = Path.Combine(path, folder,images,folderName, fileName);
            if (System.IO.File.Exists(resultPath))
            {
                System.IO.File.Delete(resultPath);
            }
        }
    }
    public enum Roles
    {
        Admin,
        Member,
        Superadmin
    }
}
