using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Model
{
    public class BorrowBook : BaseEntity
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; } //ödünc alınan tarih

        [Required]
        public DateTime BringDate { get; set; } //getirecegi tarih
        public DateTime? BroughtDate { get; set; } //getirdigi tarih //null olunca hata veriyordu sonuna ? koyduk null olabiliyor.
        public virtual Member Member { get; set; } //member'dan ayrı veri almamak için ekledim

        public virtual Book Book { get; set; } //member id yukaridan kitap id buradan gelcek
    }
}
