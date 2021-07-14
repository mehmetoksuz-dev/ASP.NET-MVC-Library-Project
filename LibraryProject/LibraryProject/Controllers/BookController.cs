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
    public class BookController : Controller
    {
        // GET: Book
        UnitOfWork unitofWork;
        public BookController()
        {
            unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var books = unitofWork.GetRepository<Book>().GetAll();
            return View(books);
        }

        public ActionResult AddBook()
        {
            ViewBag.Categories = unitofWork.GetRepository<Category>().GetAll();
            ViewBag.Writers = unitofWork.GetRepository<Writer>().GetAll();
            return View();
        }
        
        [HttpPost]
        public JsonResult AddBookJson(string[] categoriess, string writer, string bookName, string numOfBook, string rowOfBook)
        {
            if (categoriess != null && !string.IsNullOrEmpty(writer) && !string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(numOfBook) && !string.IsNullOrEmpty(rowOfBook))
            {
                List<Category> lstCtg = new List<Category>();
                foreach (var ctgIds in categoriess)
                {
                    var categoryId = Convert.ToInt32(ctgIds);
                    var ctg = unitofWork.GetRepository<Category>().GetById(categoryId);
                    lstCtg.Add(ctg);
                }
                Book book = new Book(); //gelen verileri ekledik
                book.Name = bookName;
                book.Number = Convert.ToInt32(numOfBook);
                book.WriterId = Convert.ToInt32(writer);
                book.RowNumber = rowOfBook;
                book.Categories = lstCtg;
                book.DateOfUpload = DateTime.Now;
                unitofWork.GetRepository<Book>().Add(book); //kitabı ekledik

                var situation = unitofWork.SaveChanges();//kaydettik
                if (situation > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("notNull"); //bos olamaz diye uyari vericek
            }
        }


        [HttpPost]
        public JsonResult DeleteJson(int bookId)
        {
            unitofWork.GetRepository<Book>().Delete(bookId);
            var situation = unitofWork.SaveChanges();//kaydettik
            if (situation > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        public ActionResult Update(int bookId)
        {
            ViewBag.Categories = unitofWork.GetRepository<Category>().GetAll();
            ViewBag.Writers = unitofWork.GetRepository<Writer>().GetAll();
            var book = unitofWork.GetRepository<Book>().GetById(bookId);
            return View(book);
        }
        
        [HttpPost]
        public JsonResult UpdateBookJson(int bookId, string[] categoriess, string writer, string bookName, string numOfBook, string rowOfBook)
        {
            if (categoriess != null && !string.IsNullOrEmpty(writer) && !string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(numOfBook) && !string.IsNullOrEmpty(rowOfBook))
            {
                List<Category> lstCtg = new List<Category>();
                foreach (var ctgIds in categoriess)
                {
                    var categoryId = Convert.ToInt32(ctgIds);
                    var ctg = unitofWork.GetRepository<Category>().GetById(categoryId);
                    lstCtg.Add(ctg);
                }
                var book = unitofWork.GetRepository<Book>().GetById(bookId); //kitap id gönderdik veriyi aldık altta değiştirdik
                book.Name = bookName;
                book.Number = Convert.ToInt32(numOfBook);
                book.WriterId = Convert.ToInt32(writer);
                book.RowNumber = rowOfBook;
                book.Categories.Clear();//veri eklemeden önce içeridekileri sildik kod throw'a düşüyordu
                book.Categories = lstCtg;

                unitofWork.GetRepository<Book>().Update(book); //kitabı editledik

                var situation = unitofWork.SaveChanges();//kaydettik
                if (situation > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("notNull"); //bos olamaz diye uyari vericek
            }
        }
    }
}