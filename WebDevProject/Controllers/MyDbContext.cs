using Microsoft.EntityFrameworkCore;
using WebDevProject.Models;

namespace WebDevProject.Controllers
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
