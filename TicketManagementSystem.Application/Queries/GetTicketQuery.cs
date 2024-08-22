using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Queries
{
    public class GetTicketQuery: IRequest<IEnumerable<Ticket>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
