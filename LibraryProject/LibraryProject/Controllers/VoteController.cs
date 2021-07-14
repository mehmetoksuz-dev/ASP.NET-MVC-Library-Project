using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Data.Model;
using Library.Data.UnitOfWork;
using LibraryProject.SupporterClasses;

namespace LibraryProject.Controllers
{
    [RoleControl]
    public class VoteController : Controller
    {
        // GET: Vote
        readonly UnitOfWork unitofWork;
        public VoteController()
        {
            unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var voteBooks = unitofWork.GetRepository<Book>().GetAll(); //get all books
            return View(voteBooks);
        }

        [HttpPost]
        public JsonResult VoteJson(int bookId)
        {
            if (bookId == 0) { return Json("err"); }
            var updatedRate = unitofWork.GetRepository<Book>().GetById(bookId);
            updatedRate.bookRate += 1;
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
                return Json("1");
            else return Json("0");
        }
    }
}