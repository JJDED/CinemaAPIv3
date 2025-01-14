using AutoMapper;
using DataModels.Repositories;
using DataModels.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels.Models.DTO.Showtime;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IShowtimeRepository showtimeRepository;

        // CREATE Showtime - POST: /api/showtime
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddShowtimeRequestDto addShowtimeRequestDto)
        {
            // Map DTO to Domain
            var showtimeDomainModel = mapper.Map<ShowtimesModel>(addShowtimeRequestDto);

            await showtimeRepository.CreateAsync(showtimeDomainModel);

            // Map Domain to Domain
            return Ok(mapper.Map<ShowtimesDto>(showtimeDomainModel));
        }

        // GET ALL Showtimes - GET: /api/showtimes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Map DTO to Domain
            var showtimeDomainModel = await showtimeRepository.GetAllAsync();

            // Map Domain to DTO
            return Ok(mapper.Map<List<ShowtimesDto>>(showtimeDomainModel));
        }

        // GET BY ID Showtimes - GET /api/showtimes/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Map DTO to Domain
            var showtimesDomainModel = await showtimeRepository.GetByIdAsync(id);

            if (showtimesDomainModel == null)
            {
                return NotFound();
            }

            // Map Domamin to DTO
            return Ok(mapper.Map<ShowtimesDto> (showtimesDomainModel));
        }

        // UPDATE Showtimes - PUT /api/showtimes/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShowtimesRequestDto updateShowtimesRequestDto)
        {
            // Map DTO to Domain
            var showtimesDomainModel = mapper.Map<ShowtimesModel>(updateShowtimesRequestDto);

            showtimesDomainModel = await showtimeRepository.UpdateAsync(id, showtimesDomainModel); ;

            if (showtimesDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<ShowtimesDto>(showtimesDomainModel));
        }

        // DELETE BY ID Showtimes - DELETE: /api/showtimes/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedShowtimesDomainModel = await showtimeRepository.DeleteAsync(id);
            
            if (deletedShowtimesDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<ShowtimesDto>(deletedShowtimesDomainModel));
        }
    }
}
