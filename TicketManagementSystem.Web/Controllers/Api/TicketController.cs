using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Application.Commands;
using TicketManagementSystem.Application.Queries;

namespace TicketManagementSystem.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketCommand command)
        {
            var ticketId = await _mediator.Send(command);
            return Ok(ticketId);
        }


        [HttpGet("List")]
        public async Task<IActionResult> ListTickets([FromQuery] GetTicketQuery query)
        {
            var tickets = await _mediator.Send(query);
            return Ok(tickets);
        }
    }
}
