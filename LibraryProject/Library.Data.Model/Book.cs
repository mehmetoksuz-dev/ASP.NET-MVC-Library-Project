using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Model
{
    public class Book : BaseEntity
    {
        [Required] //zorunlu
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; } 

        [Required] //zorunlu
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string RowNumber { get; set; } //sıra no mantığı

        [Required]
        public int Number { get; set; } //adet

        [Required]
        public DateTime DateOfUpload { get; set; } //eklenme trh 

        [Required]
        public int WriterId { get; set; }
        
        public int bookRate { get; set; }

        public virtual Writer Writer { get; set; } //Not: İlişkili tüm verileri almak için virtual kullandım,
                                                   //kullanmamış olsaydım sürekli Include("xx") gibi diğer tabloları dahil etmem gerekirdi.

        public virtual List<Category> Categories { get; set; } //kitap ve kategoriyi birbirine bağlıyoruz 
    }
}
