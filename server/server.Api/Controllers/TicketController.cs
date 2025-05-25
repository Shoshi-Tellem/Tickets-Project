using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.Core.DTOs;
using server.Core.Entities;
using server.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(ITicketService ticketService, IMapper mapper) : ControllerBase
    {
        private readonly ITicketService _ticketService = ticketService;
        private readonly IMapper _mapper = mapper;

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> Get()
        {
            IEnumerable<Ticket> tickets = await _ticketService.GetTicketsAsync();
            return Ok(_mapper.Map<IEnumerable<TicketDto>>(tickets));
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> Get(int id)
        {
            Ticket? ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();
            return Ok(_mapper.Map<TicketDto>(ticket));
        }

        // POST api/<TicketController>
        [HttpPost]
        public async Task<ActionResult<Ticket>> Post([FromBody] Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Ticket cannot be null.");
            Ticket addedTicket = await _ticketService.AddTicketAsync(new Ticket
            {
                FullName = ticket.FullName,
                Email = ticket.Email,
                StatusId = 1,
                Description = ticket.Description,
                Summary = null,
                ImageUrl = ticket.ImageUrl,
                Solution = null
            });
            return CreatedAtAction(nameof(Get), new
            {
                id = addedTicket.TicketId
            }, addedTicket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> Put(int id, [FromBody] int status)
        {
            Ticket? ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();
            Ticket? updatedTicket = await _ticketService.UpdateTicketStatusAsync(id, status);
            if (updatedTicket == null)
                return NotFound();
            return Ok(updatedTicket);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> Delete(int id)
        {
            Ticket? deletedTicket = await _ticketService.DeleteTicketAsync(id);
            if (deletedTicket == null)
                return NotFound();
            return Ok(deletedTicket);
        }
    }
}
