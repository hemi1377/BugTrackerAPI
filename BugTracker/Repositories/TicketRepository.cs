using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context;
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task Delete(int id)
        {
            var ticketToDelete = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticketToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> Get(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task Update(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
