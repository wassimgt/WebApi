using Microsoft.EntityFrameworkCore;
using WebApi.entites;

namespace WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<genre> genres { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
       
    }
}
