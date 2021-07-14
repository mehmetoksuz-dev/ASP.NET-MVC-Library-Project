using Library.Data.Model;
using Library.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        private readonly UnitOfWork _unitofWork;
        public StatisticsController()
        {
            _unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            ViewBag.CategoryCount = _unitofWork.GetRepository<Category>().GetAll().Count();
            ViewBag.WriterCount = _unitofWork.GetRepository<Writer>().GetAll().Count();
            ViewBag.BookCount = _unitofWork.GetRepository<Book>().GetAll().Count();
            //teslim edilen 
            ViewBag.BorrowedBookCount = _unitofWork.GetRepository<BorrowBook>().Count(x=> x.BroughtDate == null);
            //teslim alınan
            ViewBag.DeliveredBookCount = _unitofWork.GetRepository<BorrowBook>().Count(x => x.BroughtDate != null);

            var lastWeek = DateTime.Now.AddDays(-6);
            //bi hafta içerisinde alınanlar
            //ViewBag.LastWeekBorrowed = ViewBag.BorrowedBookCount + ViewBag.DeliveredBookCount(); //burası haftayı vermedi totali verdi
            ViewBag.LastWeekBorrowed = _unitofWork.GetRepository<BorrowBook>().Count(x => x.BorrowDate > lastWeek ); //delivered+borrowed 1 hafta içerisinde
            ViewBag.LastWeekDelivered = _unitofWork.GetRepository<BorrowBook>().Count(x => x.BroughtDate != null && x.BroughtDate > lastWeek);
            return View();
        }
    }
}