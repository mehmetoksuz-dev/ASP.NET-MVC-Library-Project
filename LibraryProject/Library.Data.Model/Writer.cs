using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Model
{
    public class Writer : BaseEntity
    {
        [Required] //zorunlu
        [Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual List<Book> Books {get;set;}
    }
}
