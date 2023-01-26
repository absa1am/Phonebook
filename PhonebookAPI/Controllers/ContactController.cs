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
    }
}
