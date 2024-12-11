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
    public class SeatController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISeatRepository seatRepository;

        public SeatController(IMapper mapper, ISeatRepository iseatRepository)
        {
            this.mapper = mapper;
            this.seatRepository = iseatRepository;
        }

        // CREATE Seat - POST: /api/seat
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSeatRequestDto addSeatRequestDto)
        {
            // Map DTO to Domain
            var seatDomainModel = mapper.Map<Seat>(addSeatRequestDto);

            await seatRepository.CreateAsync(seatDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<SeatDto>(seatDomainModel));
        }

        // GET Seat BY ID - GET: /api/seat/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Map DTO to Domain
            var seatDomainModel = await seatRepository.GetByIdAsync(id);

            if (seatDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<SeatDto>(seatDomainModel));
        }

        // GET ALL Seat - GET: /api/seat
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seatDomainModel = await seatRepository.GetAllAsync();

            // Map Domain to DTO
            return Ok(mapper.Map<List<SeatDto>>(seatDomainModel));
        }

        // UPDATE Seat - PUT: /api/seat/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSeatRequestDto updateSeatRequestDto)
        {
            // Map DTO to Domain
            var seatDomainModel = mapper.Map<Seat>(updateSeatRequestDto);

            seatDomainModel = await seatRepository.UpdateAsync(id, seatDomainModel);

            if (seatDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<SeatDto>(seatDomainModel));
        }

        // DELETE Seat - DELETE: /api/seat/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedSeat = await seatRepository.DeleteAsync(id);

            if (deletedSeat == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<SeatDto>(deletedSeat));
        }
    }
}
