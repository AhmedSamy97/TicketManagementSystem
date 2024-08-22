using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Infrastructure.Data;

namespace TicketManagementSystem.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _context;
        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.ID;
        }

        public async Task<List<Ticket>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(Guid id)
        {
            return await _context.Tickets.FindAsync(id);
        }
    }
}
