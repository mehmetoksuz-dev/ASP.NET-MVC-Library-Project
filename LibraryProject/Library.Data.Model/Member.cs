using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Model
{
    public class Member : BaseEntity //uye bilgileri
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)] //tc 11 karakterli oldugu için.
        public string TcNo { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)] //tc ile aynı mantık
        public string PhoneNum { get; set; }

        [Required]
        public DateTime RegTime { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(80)]
        public string Mail { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(32), MinLength(32)] //db'ye kaydı MD5 ya da SHA olarak alacağım lenght ona göre değişecek.
        public string Pass { get; set; }

        [Required]
        public int Punishment { get; set; } //ceza sistemi


        [Column(TypeName = "char")]
        [MaxLength(1), MinLength(1)]
        public string Role { get; set; } //yetki sistemi

        public virtual List<BorrowBook> BorrowBooks { get; set; }
    }
}
