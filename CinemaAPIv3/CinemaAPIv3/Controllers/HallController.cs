using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO;
using DataModels.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : Controller
    {
        private readonly IMapper mapper;
        private readonly IHallRepository hallRepository;

        public HallController(IMapper mapper, IHallRepository hallRepository)
        {
            this.mapper = mapper;
            this.hallRepository = hallRepository;
        }

        // CREATE Hall - POST: /api/hall
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAddressRequestDto addAddressRequestDto)
        {
            // Map DTO to Domain
            var hallDomainModel = mapper.Map<Hall>(addAddressRequestDto);

            await hallRepository.CreateAsync(hallDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<HallDto>(hallDomainModel));
        }

        // GET Hall - GET: /api/hall
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var hallDomainModel = await hallRepository.GetAllAsync();

            // Map Domain to DTO
            return Ok(mapper.Map<List<HallDto>> (hallDomainModel));
        }

        // GET ALL Hall - Get: /api/hall/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hallDomainModel = await hallRepository.GetByIdAsync(id);

            if (hallDomainModel == null) 
            { 
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<HallDto>(hallDomainModel));
        }

        // UPDATE Hall - PUT: /api/hall/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHallRequestDto updateHallRequestDto)
        {
            // Map DTO to Domain
            var hallDomainModel = mapper.Map<Hall>(updateHallRequestDto);

            hallDomainModel = await hallRepository.UpdateAsync(id, hallDomainModel);

            if (hallDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<HallDto>(hallDomainModel));
        }

        // DELETE Hall - DELETE: /api/hall/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Map DTO to Domain
            var hallDomainModel = await hallRepository.DeleteAsync(id);
            if (hallDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain to DTO
            return Ok(mapper.Map<HallDto>(hallDomainModel));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
