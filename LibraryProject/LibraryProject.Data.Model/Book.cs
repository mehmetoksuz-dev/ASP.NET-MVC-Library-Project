using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Model
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string RowNumber { get; set; } //sıra no mantığı

        public int Number { get; set; }
        public DateTime DateOfUpload { get; set; }

        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        public List<Category> Categories { get; set; }
    }
}
