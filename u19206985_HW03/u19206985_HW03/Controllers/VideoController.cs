using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19206985_HW03.Models;

namespace u19206985_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            List<FileModel> myFiles = new List<FileModel>();

            foreach (string file in files)
            {
                myFiles.Add(new FileModel { FileName = Path.GetFileName(file) });
            }
            return View(myFiles);
          
        }

        public FileResult DownloadFile(string filename)
        {
            string path = Server.MapPath("~/Media/Videos/") + filename;


            byte[] bytes = System.IO.File.ReadAllBytes(path);


            return File(bytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteFile(string filename)
        {
            string path = Server.MapPath("~/Media/Videos/") + filename;
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                file.Delete();
            }


            return RedirectToAction("Index");
        }
    }
}