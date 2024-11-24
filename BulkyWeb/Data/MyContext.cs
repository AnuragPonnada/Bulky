using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    // Inheriting db context class
    public class MyContext : DbContext
    {
        //constructor
        public MyContext(DbContextOptions<MyContext> options) :base(options)
        {

        }
        // importing entity class, creating the table name as student
        public DbSet<MyData> Student { get; set; }
        
    }
}
