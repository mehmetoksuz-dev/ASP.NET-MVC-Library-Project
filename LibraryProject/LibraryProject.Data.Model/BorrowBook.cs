using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Model
{
    public class BorrowBook : BaseEntity
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; } //ödünc alınan tarih
        public DateTime BringDate { get; set; } //getirecegi tarih
        public DateTime? BroughtDate { get; set; } //getirdigi tarih //null olunca hata veriyordu sonuna ? koyduk null olabiliyor.
    }
}
