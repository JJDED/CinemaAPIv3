using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO.PostalCode;
using DataModels.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPostalCodeRepository postalCodeRepository;

        public PostalCodesController(IMapper mapper, IPostalCodeRepository postalCodeRepository)
        {
            this.mapper = mapper;
            this.postalCodeRepository = postalCodeRepository;
        }

        // CREATE PostalCodes - POST: /api/postalcodes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPostalCodeRequestDto addPostalCodeRequestDto)
        {
            // Map DTO to Domain
            var postalCodeDomainModel = mapper.Map<PostalCodeModel>(addPostalCodeRequestDto);

            await postalCodeRepository.CreateAsync(postalCodeDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<PostalCodeDto>(postalCodeDomainModel));
        }

        // GET PostalCode
        // GET: /api/PostalCode

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postalCodesDomainModel = await postalCodeRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<PostalCodeDto>>(postalCodesDomainModel));
        }

        // Get PostalCode By Id
        // GET; /api/PostalCodes/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var postalCodeDomainModel = await postalCodeRepository.GetByIdAsync(id);

            if (postalCodeDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(mapper.Map<PostalCodeDto>(postalCodeDomainModel));
        }

        // UPDATE PostalCode - PUT: /api/PostalCode/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostalCodeRequestDto updatePostalCodeRequestDto)
        {
            // Map DTO to Domain
            var postalCodeDomainModel = mapper.Map<PostalCodeModel>(updatePostalCodeRequestDto);

            postalCodeDomainModel = await postalCodeRepository.UpdateAsync(id, postalCodeDomainModel);

            if (postalCodeDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<PostalCodeModel>(postalCodeDomainModel));
        }

        // DELETE Seat - DELETE: /api/seat/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPostalCode = await postalCodeRepository.DeleteAsync(id);

            if (deletedPostalCode == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<PostalCodeDto>(deletedPostalCode));
        }
    }
}
