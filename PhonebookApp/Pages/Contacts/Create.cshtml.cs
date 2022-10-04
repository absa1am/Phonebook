using PhonebookApp.Data;
using PhonebookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhonebookApp.Pages.Contacts;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;

    [BindProperty]
    public Contact Contact { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> OnPost()
    {
        await _db.Contact.AddAsync(Contact);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}