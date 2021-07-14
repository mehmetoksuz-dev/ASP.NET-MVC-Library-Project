using Library.Data.Migrations;
using Library.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Context:DbContext
    {
        public Context():base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("Context")); //migrations yapısını burada kullanıyorum
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //veritabanında her şeyin sonuna 's' ekliyordu onu kaldırdım
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
