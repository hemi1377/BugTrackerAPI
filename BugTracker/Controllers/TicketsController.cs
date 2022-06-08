using BugTracker.Models;
using BugTracker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _ticketRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTickets(int id)
        {
            return await _ticketRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>>PostTickets([FromBody] Ticket ticket)
        {
            var newTicket = await _ticketRepository.Create(ticket);
            return CreatedAtAction(nameof(GetTickets), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Ticket ticket)
        {
            if(id != ticket.Id)
            {
                return BadRequest();
            }

            await _ticketRepository.Update(ticket);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var ticketToDelete = await _ticketRepository.Get(id);
            if (ticketToDelete == null)
                return NotFound();

            await _ticketRepository.Delete(ticketToDelete.Id);
            return NoContent();
        }
    }
}
