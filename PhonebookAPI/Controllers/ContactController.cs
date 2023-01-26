using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhonebookAPI.Contexts;
using PhonebookAPI.Models;

namespace PhonebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactModel>>> GetContacts()
        {
            List<ContactModel> contacts = appDbContext.Contacts.ToList();

            if (contacts == null || contacts.Count == 0)
                return NotFound("Sorry, contact(s) not found.");

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(ContactModel request)
        {
            if (request == null)
                return NotFound("Sorry, failed to create contact.");

            var contact = new ContactModel();

            contact.Name = request.Name;
            contact.Phone = request.Phone;
            contact.Email = request.Email;

            await appDbContext.Contacts.AddAsync(contact);
            await appDbContext.SaveChangesAsync();

            return Ok("Contact added successfully.");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateContact(int id, ContactModel request)
        {
            ContactModel contact = await appDbContext.Contacts.FindAsync(id);

            if (contact is null)
                return NotFound("Sorry, contact doesn't exist.");

            contact.Name = request.Name;
            contact.Phone = request.Phone;
            contact.Email = request.Email;

            await appDbContext.SaveChangesAsync();

            return Ok("Contact updated successfully.");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteContact(int id)
        {
            ContactModel contact = appDbContext.Contacts.Find(id);

            if (contact is null)
                return NotFound("Sorry, contact doesn't exist.");

            appDbContext.Remove(contact);
            appDbContext.SaveChanges();

            return Ok("Contact deleted successfully.");
        }
    }
}
