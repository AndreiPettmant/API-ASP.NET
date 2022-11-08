using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDBContext dBContext;
        public IssueController(IssueDBContext context) => dBContext = context;

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
            => await dBContext.Issues.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await dBContext.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await dBContext.Issues.AddAsync(issue);
            await dBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id) return BadRequest();

            dBContext.Entry(issue).State = EntityState.Modified;
            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await dBContext.Issues.FindAsync(id);

            if (issueToDelete == null) return NotFound();

            dBContext.Issues.Remove(issueToDelete);
            await dBContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
