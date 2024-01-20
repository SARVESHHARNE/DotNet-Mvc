using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { 
            
        }
    }
}
