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
    public class MemberController : Controller
    {
        // GET: Member
        UnitOfWork unitofWork;
        public MemberController()
        {
            unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var members = unitofWork.GetRepository<Member>().GetAll();
            return View(members);
        }
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddMemberJson(string memberName, string memberSurname, string memberTc, string memberPhone)
        {
            if (memberTc.Length > 11 || memberPhone.Length > 11) return Json("notNull");

            if (!string.IsNullOrEmpty(memberName) && !string.IsNullOrEmpty(memberSurname))
            {
                Member member = new Member();
                member.Name = memberName;
                member.Surname = memberSurname;
                member.TcNo = memberTc.ToString();
                member.PhoneNum = memberPhone.ToString();
                member.Punishment = 0;
                member.RegTime = DateTime.Now;
                member.Role = "3";

                unitofWork.GetRepository<Member>().Add(member);
                var situation = unitofWork.SaveChanges();
                if (situation > 0)
                    return Json("1");
                else return Json("0");
            }
            else
            {
                return Json("notNull");
            }
        }

        [HttpPost]
        public JsonResult DeleteMemberJson(int memberId)
        {
            unitofWork.GetRepository<Member>().Delete(memberId);
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

        public ActionResult Update(int memberId) //update sayfasını döndürüyoruz
        {
            var member = unitofWork.GetRepository<Member>().GetById(memberId);
            return View(member);
        }

        [HttpPost]
        public JsonResult UpdateMemberJson(int memberId, string memberName, string memberSurname, string memberTc, string memberPhone)
        {
            if (!string.IsNullOrEmpty(memberName) && !string.IsNullOrEmpty(memberSurname))
            {
                var member = unitofWork.GetRepository<Member>().GetById(memberId);
                member.Name = memberName;
                member.Surname = memberSurname;
                member.TcNo = memberTc;
                member.PhoneNum = memberPhone;
                unitofWork.GetRepository<Member>().Update(member);
                var situation = unitofWork.SaveChanges();
                if (situation > 0)
                    return Json("1");
                else return Json("0");
            }
            else
            {
                return Json("notNull");
            }
        }
    }
}