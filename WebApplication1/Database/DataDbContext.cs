using Microsoft.EntityFrameworkCore; // impory EF
using WebApplication1.Models;// import Model




namespace WebApplication1.Database
{
    public class DataDbContext:DbContext
    {
        // Constructor Method
        public DataDbContext(DbContextOptions<DataDbContext> options):base(options) { }
        // Take menufacturers
        public DbSet<menufacturers> menufacturers { get; set; }

        // Tale devices
        public DbSet<devices> devices { get; set; }

    }
}
