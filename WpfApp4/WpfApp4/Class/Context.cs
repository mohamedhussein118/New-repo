using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Class
{
    internal class Context: DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM170-LAB3\\SQLEXPRESS;Initial Catalog=Center;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
