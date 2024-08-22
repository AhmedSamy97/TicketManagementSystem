﻿using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Infrastructure.Data
{
    public class TicketDbContext :DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
            
        }
        public DbSet<Ticket> Tickets { get; set; }

        
    }
}
