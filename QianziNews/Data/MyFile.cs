using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace QianziNews.Data
{
    public class MyFile
    {

        public static async Task Up(string path,IEnumerable<IFormFile> files)
        {
            if (files.Count()>0)
            {
                foreach(IFormFile f in files)
                {
                    string filePath = Path.Combine(path, f.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await f.CopyToAsync(stream);
                    }
                }

            }
        }

        public static void Remove(IEnumerable<string> paths)
        {
            if (paths.Count() > 0)
            {
                foreach(string p in paths)
                {
                    try
                    {
                        File.Delete(p);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
