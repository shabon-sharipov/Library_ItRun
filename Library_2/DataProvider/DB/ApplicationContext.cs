using Library_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.DataProvider.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Categoriy> Categories { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Book> Books { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\DataBase\\LibraryConsol.db");
        }
    }
}
