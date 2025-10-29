using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_OneToOneApiDemo.Data;
using Microsoft.EntityFrameworkCore;
using WebApi_OneToOneApiDemo.Models;

namespace WebApi_OneToOneApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PersonsController(AppDbContext db) => _db = db;

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = person.PersonId }, person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _db.Persons.Include(p => p.Passport)
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null) return NotFound();
            return Ok(person);
        }
    }
}
