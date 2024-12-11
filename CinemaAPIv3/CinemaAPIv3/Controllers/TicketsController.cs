using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO;
using DataModels.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITicketRepository ticketRepository;

        public TicketsController(IMapper mapper, ITicketRepository ticketRepository)
        {
            this.mapper = mapper;
            this.ticketRepository = ticketRepository;
        }

        // CREATE Ticket - POST: /api/tickets
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTicketRequestDto addTicketRequestDto)
        {
            // Map DTO to Domain
            var ticketDomainModel = mapper.Map<Tickets>(addTicketRequestDto);

            await ticketRepository.CreateAsync(ticketDomainModel);

            return Ok(mapper.Map<Tickets>(addTicketRequestDto));
        }

        // GET ALL Ticket - GET: /api/tickets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Map Domain to DTO
            var ticketDomainModel = await ticketRepository.GetAllAsync();

            // Map DTO to Domain
            return Ok(mapper.Map<List<TicketsDto>>(ticketDomainModel));
        }

        // GET BY ID Tickets - GET: /api/tickets/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Map DTO to Domain
            var ticketDomainModel = await ticketRepository.GetByIdAsync(id);

            if (ticketDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<Tickets>(ticketDomainModel));
        }

        // UPDATE Tickets - PUT: /api/tickets/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTicketRequestDto updateTicketRequestDto)
        {
            // Map DTO to Domain
            var ticketDomainModel = mapper.Map<Tickets>(updateTicketRequestDto);

            ticketDomainModel = await ticketRepository.UpdateAsync(id, ticketDomainModel);

            // Map Domain to DTO
            if (ticketDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TicketsDto>(ticketDomainModel));
        }

        // DELETE Tickets - DELETE: /api/tickets/{api}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Map DTO to Domain
            var deletedTicketDomainModel = await ticketRepository.DeleteAsync(id);
            if (deletedTicketDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<UserDto>(deletedTicketDomainModel));
        }
    }
}
