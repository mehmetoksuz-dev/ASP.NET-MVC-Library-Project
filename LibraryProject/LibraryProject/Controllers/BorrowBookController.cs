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
    public class BorrowBookController : Controller
    {
        UnitOfWork unitofWork;
        public BorrowBookController()
        {
            unitofWork = new UnitOfWork();
        }
        public ActionResult BookSuplied()
        {
            var borrowBook = unitofWork.GetRepository<BorrowBook>().GetAll(x => x.BroughtDate == null);
            return View(borrowBook);
        }

        public ActionResult BookDelivered()
        {
            var borrowBook = unitofWork.GetRepository<BorrowBook>().GetAll(x=>x.BroughtDate != null); //db'de BroughtDate null olmayacagi icin
            return View(borrowBook);
        }

        public ActionResult GiveBook()
        {
            ViewBag.Books = unitofWork.GetRepository<Book>().GetAll( x => x.Number > 0); //kalmamışsa gösterme
            ViewBag.Members = unitofWork.GetRepository<Member>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult GiveBookJson(int memberId, int bookId, DateTime bringDate)
        {
            BorrowBook borrowBook = new BorrowBook();
            borrowBook.BorrowDate = DateTime.Now;
            borrowBook.BringDate = bringDate;
            borrowBook.BookId = bookId;
            borrowBook.MemberId = memberId;

            unitofWork.GetRepository<BorrowBook>().Add(borrowBook);
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
                return Json("1");
            else return Json("0");
        }

        public ActionResult UpdateBorrowBook(int borrowBookId)
        {
            ViewBag.Books = unitofWork.GetRepository<Book>().GetAll(x => x.Number > 0); //kalmamışsa gösterme
            ViewBag.Members = unitofWork.GetRepository<Member>().GetAll();
            var borrowBook = unitofWork.GetRepository<BorrowBook>().GetById(borrowBookId);
            return View(borrowBook);
        }

        [HttpPost]
        public JsonResult UpdateBorrowBookJson(int borrowBookId, int memberId, int bookId, DateTime bringDate)
        {
            var borrowBook = unitofWork.GetRepository<BorrowBook>().GetById(borrowBookId);

            borrowBook.BringDate = bringDate; //getireceği tarih
            borrowBook.BookId = bookId;
            borrowBook.MemberId = memberId;

            unitofWork.GetRepository<BorrowBook>().Update(borrowBook);
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
                return Json("1");
            else return Json("0");
        }

        [HttpPost]
        public JsonResult DeliveredMarkJson(int borrowBookId)
        {
            var borrowBook = unitofWork.GetRepository<BorrowBook>().GetById(borrowBookId);
            borrowBook.BroughtDate = DateTime.Now;
            unitofWork.GetRepository<BorrowBook>().Update(borrowBook);
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
                return Json("1");
            else return Json("0");
        }
    }
}