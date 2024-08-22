using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Application.Queries;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Handlers
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery,IEnumerable<Ticket>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<IEnumerable<Ticket>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAllAsync(request.PageNumber, request.PageSize);
            return tickets;
        }
    }
}
