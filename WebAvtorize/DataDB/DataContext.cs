using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Models;

namespace WebAvtorize.DataDB
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
            
               
        }


       
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

       

    }
}
