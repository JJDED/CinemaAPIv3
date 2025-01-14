using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO.Theater;
using DataModels.Models.DTO.User;
using DataModels.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITheaterRepository theaterRepository;

        public TheatersController(IMapper mapper, ITheaterRepository theaterRepository)
        {
            this.mapper = mapper;
            this.theaterRepository = theaterRepository;
        }

        // CREATE Theater - POST: /api/theater/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTheaterRequestDto addTheaterRequestDto)
        {
            // Map DTO to Domain
            var theaterDomainModel = mapper.Map<TheaterModel>(addTheaterRequestDto);

            await theaterRepository.CreateAsync(theaterDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<UserDto>(theaterDomainModel));
        }

        // GET ALL Theater - GET: /api/theater
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Map DTO to Domain
            var theaterDomainModel = await theaterRepository.GetAllAsync();

            // Map Domain to DTO
            return Ok(mapper.Map<List<TheaterDto>>(theaterDomainModel));
        }

        // GET BY ID Theater - GET: /api/theater/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Map DTO to Domain
            var theaterDomainModel = await theaterRepository.GetByIdAsync(id);

            if (theaterDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<TheaterDto>(theaterDomainModel));
        }

        // UPDATE Theater - PUT: /api/theater/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTheaterRequestDto updateTheaterRequestDto)
        {
            // Map DTO to Domain
            var theaterDomainModel = mapper.Map<TheaterModel>(updateTheaterRequestDto);

            theaterDomainModel = await theaterRepository.UpdateAsync(id, theaterDomainModel);

            if (theaterDomainModel == null)
            {
                return NotFound();
            }

            // Map Domamin to DTO
            return Ok(mapper.Map<TheaterDto>(theaterDomainModel));
        }

        // DELETE Theater - DELETE: /api/theater/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Map DTO to Domain
            var deletedTheaterDomainModel = await theaterRepository.DeleteAsync(id);

            if (deletedTheaterDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<TheaterDto>(deletedTheaterDomainModel));
        }
    }
}
