using BugTracker.Models;

namespace BugTracker.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> Get();

        Task<Ticket> Get(int id);

        Task<Ticket> Create(Ticket ticket);

        Task Update(Ticket ticket);

        Task Delete(int id);

    }
}
