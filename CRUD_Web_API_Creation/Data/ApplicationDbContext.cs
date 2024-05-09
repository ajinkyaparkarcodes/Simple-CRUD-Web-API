using CRUD_Web_API_Creation.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API_Creation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Emp> Emps { get; set; }
    }
}
