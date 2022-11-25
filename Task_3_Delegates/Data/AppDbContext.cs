using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Task_3_Delegates.Models;

namespace Task_3_Delegates.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
