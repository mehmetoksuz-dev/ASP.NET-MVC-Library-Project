using Library.Data;
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
    [RoleControl] //alta ekleyince sadece eklenen yer için çalışıyordu örnegin index üstüne ekleyince sadece indexi engelliyordu
    public class CategoryController : Controller
    {
        // GET: Category
        UnitOfWork unitofWork;
        public CategoryController() //yapıcı method
        {
            unitofWork = new UnitOfWork();

        }
        public ActionResult Index()
        {
            var categories = unitofWork.GetRepository<Category>().GetAll(); //db islemleri //unitofwork üzerinden repository'e ulasiyoruz
            return View(categories);
        }

        [HttpPost]
        public JsonResult AddJson(string ctgName)
        {
            if (string.IsNullOrEmpty(ctgName)) return Json("error"); //ctg adi bos ise
            Category ctg = new Category();
            ctg.Name = ctgName;
            var addedCtg = unitofWork.GetRepository<Category>().Add(ctg); //eklenen veri
            unitofWork.SaveChanges(); //kaydettik
            return Json(new
            {
                Result = new
                {
                    addedCtg.Id,
                    addedCtg.Name
                },
                JsonRequestBehavior.AllowGet
            });
        }

        [HttpPost]
        public JsonResult UpdateJson(int ctgId, string ctgName)
        {
            var ctg = unitofWork.GetRepository<Category>().GetById(ctgId);
            ctg.Name = ctgName;
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
        public JsonResult DeleteJson(int ctgId)
        {
            unitofWork.GetRepository<Category>().Delete(ctgId);
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
    }
}