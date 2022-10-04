using PhonebookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PhonebookApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> Contact { get; set; }
}