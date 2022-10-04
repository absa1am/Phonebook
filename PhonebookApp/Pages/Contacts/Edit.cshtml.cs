using PhonebookApp.Data;
using PhonebookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhonebookApp.Pages.Contacts;

[BindProperties]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;


    public Contact Contact { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Contact = _db.Contact.Find(id);
    }

    public async Task<IActionResult> OnPost(Contact contact)
    {
        _db.Contact.Update(contact);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}