using Library.Data.HelperClass;
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
    public class MembershipController : Controller
    {
        // GET: Membership
        readonly UnitOfWork unitofWork;
        public MembershipController()
        {
            unitofWork = new UnitOfWork();
        }
        [RoleControl]
        public ActionResult Index()
        {
            var members = unitofWork.GetRepository<Member>().GetAll(x => x.Role != null);
            return View(members);
        }
        [RoleControl]
        public ActionResult Add()
        {
            var members = unitofWork.GetRepository<Member>().GetAll(x => x.Role == null); //yetkisi null olanlar
            return View(members);
        }

        [RoleControl]
        [HttpPost]
        public JsonResult AddJson(int memberId, string mail, string password, string passwordAgain)
        {
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(passwordAgain))
            {
                if (password == passwordAgain)
                {
                    password = PassHashing.Encrypt(password);
                    var member = unitofWork.GetRepository<Member>().GetById(memberId);
                    member.Mail = mail;
                    member.Pass = password;
                    member.Role = "3"; //1=admin, 2=mod, 3=izleyici,görüntüleme yetkisi vs.
                    unitofWork.GetRepository<Member>().Update(member);
                    var situation = unitofWork.SaveChanges();
                    if (situation > 0)
                        return Json("1");
                    else return Json("0");
                }
                else
                {
                    return Json("samePassErr");
                }
            }
            else
            {
                return Json("notNull");
            }
        }

        [RoleControl]
        public ActionResult Update(int memberId)
        {
            var member = unitofWork.GetRepository<Member>().GetById(memberId);
            
            return View(member);
        }

        [RoleControl]
        [HttpPost]
        public JsonResult UpdateJson(int memberId, string mail, string password, string passwordAgain)
        {
            if (!string.IsNullOrEmpty(mail))
            {
                if (password == passwordAgain)
                {
                    password = PassHashing.Encrypt(password);
                    var member = unitofWork.GetRepository<Member>().GetById(memberId);
                    member.Mail = mail;

                    if (!string.IsNullOrEmpty(password))
                    {
                        member.Pass = password;
                    }
                    unitofWork.GetRepository<Member>().Update(member);
                    var situation = unitofWork.SaveChanges();
                    if (situation > 0)
                        return Json("1");
                    else return Json("0");
                }
                else
                {
                    return Json("samePassErr");
                }
            }
            else
            {
                return Json("mailNotNull");
            }
        }

        [RoleControl]
        [HttpPost]
        public JsonResult DeleteJson(int memberId)
        {
            var member = unitofWork.GetRepository<Member>().GetById(memberId);
            unitofWork.GetRepository<Member>().Delete(member);
            var situation = unitofWork.SaveChanges();
            if(situation>0) 
                return Json("1");
            return Json("0");
        }

        [RoleControl]
        [HttpPost]
        public JsonResult AddRoleJson(int memberId, string roleId) //yetki atama
        {
            var member = unitofWork.GetRepository<Member>().GetById(memberId);
            member.Role = roleId;
            unitofWork.GetRepository<Member>().Update(member);
            var situation = unitofWork.SaveChanges();
            if (situation > 0)
                return Json("1");
            return Json("0");
        }

        [RoleControl]
        public ActionResult UpdateProfileInfo()
        {
            var memberId = Convert.ToInt32(Request.Cookies["member"]["Id"]);
            var member = unitofWork.GetRepository<Member>().GetById(memberId);
            return View(member);
        }

        [HttpPost]

        public JsonResult UpdateProfileInfoJson(string mail, string password, string passwordAgain, string tel)
        {
            if (string.IsNullOrEmpty(mail)) return Json("mailNotNull"); //mail bos ise
            if (password == passwordAgain)
            {
                var memberId = Convert.ToInt32(Request.Cookies["member"]["Id"]);
                var member = unitofWork.GetRepository<Member>().GetById(memberId);

                member.Mail = mail;
                member.PhoneNum = tel;

                if (!string.IsNullOrEmpty(password))
                {
                    password = PassHashing.Encrypt(password);
                    member.Pass = password;
                }

                unitofWork.GetRepository<Member>().Update(member);
                unitofWork.SaveChanges();
                return Json("1");
            }
            else return Json("samePassErr");
        }
    }
}