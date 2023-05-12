using Microsoft.EntityFrameworkCore;
using MiniApp.Models;

namespace MiniApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
