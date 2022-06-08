using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u19206985_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UploadedFile, string filetype)
        {

            if (UploadedFile !=null && UploadedFile.ContentLength > 0)
            {
                string filename = Path.GetFileName(UploadedFile.FileName);

                if (filetype == "Document")
                {
                    
                    
                        string FolderPath = Path.Combine(Server.MapPath("~/Media/Documents"), Path.GetFileName(filename));

                        UploadedFile.SaveAs(FolderPath);
                    
         
                }

                else if (filetype == "Image")
                {
                    
                    
                        string FolderPath = Path.Combine(Server.MapPath("~/Media/Images"), Path.GetFileName(filename));

                        UploadedFile.SaveAs(FolderPath);
                        

                }

                else if (filetype == "Video")
                {
                    
                    
                        string FolderPath = Path.Combine(Server.MapPath("~/Media/Videos"), Path.GetFileName(filename));

                        UploadedFile.SaveAs(FolderPath);
                    
               
                }

            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}