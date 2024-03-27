using EnteringProjectData.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EnteringProjectData.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        { 

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
