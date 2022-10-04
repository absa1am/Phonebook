using PhonebookApp.Data;
using PhonebookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhonebookApp.Pages.Contacts;

[BindProperties]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Contact Contact { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Contact = _db.Contact.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        _db.Contact.Remove(Contact);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}