using MediatR;
using TicketManagementSystem.Application.Commands;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Handlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand,Guid>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket()
            {
                ID = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                PhoneNumber = request.PhoneNumber,
                Governorate = request.Governorate,
                City = request.City,
                District = request.District
            };
            await _ticketRepository.AddAsync(ticket);
            return ticket.ID;
        }
    }
}
