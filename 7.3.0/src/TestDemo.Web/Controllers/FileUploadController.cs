using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Web.Controllers
{
    public class FileUploadController : Controller
    {
        public FileUploadController()
        {
        }
        
        public JsonResult UploadProductAttachments(HttpPostedFileBase Files)
        {
            try
            {
                if (Request.Files.Count <= 0 || Request.Files[0] == null)
                {
                    throw new UserFriendlyException("");
                }
                var files = Request.Files[0];

                var acceptedFormates = new List<string> { ".pdf", ".jpg", ".jpeg", ".doc", ".docx", ".txt", ".xls", ".xlxs" };
                var fileExt = System.IO.Path.GetExtension(files.FileName).Substring(1);
                var fileInfo = new FileInfo(files.FileName);
                if(!acceptedFormates.Contains(fileExt.ToLower()))
                {
                    // throw new UserFriendlyException("DocumentsFill");
                }
                string tempFileName = "";
                tempFileName = Path.GetFileNameWithoutExtension(files.FileName.ToString().Replace("", "_")) + "_" + DateTime.Now.ToString("ddMMyyHHmmssffff") + fileInfo.Extension;
                if(!Directory.Exists(Path.Combine(Server.MapPath("~/UserFiles/Documents/"))))
                {
                    Directory.CreateDirectory(Path.Combine(Server.MapPath("~/UserFiles/Documents/")));
                }
                var ServerSavePath = Path.Combine(Server.MapPath("~/UserFiles/Documents/") + tempFileName);
                files.SaveAs(ServerSavePath);

                return Json(new AjaxResponse(new
                {
                    fileName = tempFileName,
                    path = ""
                }));
                    
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
    
}