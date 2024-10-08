﻿

using MediatR;

namespace TicketManagementSystem.Application.Commands
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
   
}
