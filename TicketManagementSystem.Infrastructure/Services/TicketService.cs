using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Infrastructure.Data;

namespace TicketManagementSystem.Infrastructure.Services
{
    public class TicketService :ITicketService
    {
        private readonly TicketDbContext _context;

        public TicketService(TicketDbContext context)
        {
            _context = context;
        }
        public async Task UpdateTicketColorsAsync()
        {
            var tickets = _context.Tickets
                .Where(x => EF.Functions.DateDiffMinute(x.CreatedAt, DateTime.Now) <= 120 &&
                            ( x.Status != "Handled" || x.Color != "Red")).ToList(); //  get tickets created within 2 hours and not handled
            foreach (var ticket in tickets)
            {
                UpdateTicketStatus(ticket);
            }

            await _context.SaveChangesAsync();
        }

        private void UpdateTicketStatus(Ticket ticket)
        {
            var timeDifference = (DateTime.Now - ticket.CreatedAt).TotalMinutes;
            if (timeDifference >= 60)
            {
                ticket.Status = "Handled";
                ticket.Color = "Red";
            }
            else if (timeDifference >= 45)
            {
                ticket.Color = "Blue";
            }
            else if (timeDifference >= 30)
            {
                ticket.Color = "Green";
            }
            else if (timeDifference >= 15)//not required
            {
                ticket.Color = "Yellow";
            }
        }
    }
}
