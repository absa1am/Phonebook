using PhonebookApp.Data;
using PhonebookApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhonebookApp.Pages.Contacts;

public class IndexModel : PageModel
{
     private readonly ApplicationDbContext _db;
     public IEnumerable<Contact> Contacts { get; set; }

     public IndexModel(ApplicationDbContext db)
     {
        _db = db;
     }

     public void OnGet()
     {
        Contacts = _db.Contact;
     }
}