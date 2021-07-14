using Library.Data.Model;
using Library.Data.UnitOfWork;
using LibraryProject.SupporterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    [RoleControl]
    public class WriterController : Controller
    {
        // GET: Writer
        readonly UnitOfWork unitofWork;
        public WriterController()
        {
            unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var writers = unitofWork.GetRepository<Writer>().GetAll(); //db tribi
            return View(writers);
        }

        [HttpPost]
        public JsonResult AddJson(string writerName)
        {
            if (string.IsNullOrEmpty(writerName)) return Json("error"); //yazar bos ise
            Writer writer = new Writer();
            writer.Name = writerName;
            var addedWriter = unitofWork.GetRepository<Writer>().Add(writer); //eklenen veri
            unitofWork.SaveChanges();
            return Json(new
            {
                Result = new
                {
                    addedWriter.Id,
                    addedWriter.Name
                },
                JsonRequestBehavior.AllowGet
            });
        }

        [HttpPost]
        public JsonResult DeleteJson(int writerId)
        {
            unitofWork.GetRepository<Writer>().Delete(writerId);
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]
        public JsonResult UpdateJson(int writerId, string writerName)
        {
            var writer = unitofWork.GetRepository<Writer>().GetById(writerId);
            writer.Name = writerName;
            var situation = unitofWork.SaveChanges();
            if (situation > 0) 
                return Json("1");
            else return Json("0");
        }
    }
}