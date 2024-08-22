using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task<Guid> AddAsync(Ticket ticket);
        Task<List<Ticket>> GetAllAsync(int pageNumber, int pageSize);
        Task<Ticket> GetByIdAsync(Guid id);
    }
}
