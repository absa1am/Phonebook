using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Models;

namespace PhonebookAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) { }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
