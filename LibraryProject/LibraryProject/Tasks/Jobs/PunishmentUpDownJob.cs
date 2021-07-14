using Library.Data.Model;
using Library.Data.UnitOfWork;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Tasks.Jobs
{
    public class PunishmentUpDownJob : IJob
    {
        UnitOfWork unitofWork;
        public PunishmentUpDownJob()
        {
            unitofWork = new UnitOfWork();
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                PunishmentIncrease();
                PunishmentDecrease();
                unitofWork.SaveChanges();
                
            }
            catch (Exception)
            {

            }
        }

        void PunishmentIncrease() //getirecegi tarih bos ya da now'dan büyükse ceza +1
        {
            var borrowBooks = unitofWork.GetRepository<BorrowBook>().GetAll(x => x.BroughtDate == null && DateTime.Now > x.BringDate);
            foreach (var borrowBook in borrowBooks)
            {
                borrowBook.Member.Punishment += 1;
                unitofWork.GetRepository<Member>().Update(borrowBook.Member);
            }
        }
        void PunishmentDecrease()  //getirecegi tarih bos degil ya da ceza > 0 ise -1 at
        {
            var borrowBooks = unitofWork.GetRepository<BorrowBook>().GetAll(x => x.BroughtDate != null && x.Member.Punishment>0);
            foreach (var borrowBook in borrowBooks)
            {
                borrowBook.Member.Punishment -= 1;
                unitofWork.GetRepository<Member>().Update(borrowBook.Member);
            }
        }
    }
}