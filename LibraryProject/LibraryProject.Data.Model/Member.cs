using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Model
{
    public class Member : BaseEntity //uye bilgileri
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }
        public string PhoneNum { get; set; }
        public DateTime RegTime { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public int Punishment { get; set; } //ceza sistemi //bool olabilir
        public char Role { get; set; } //yetki sistemi

        public List<BorrowBook> BorrowBooks { get; set; }
    }
}
