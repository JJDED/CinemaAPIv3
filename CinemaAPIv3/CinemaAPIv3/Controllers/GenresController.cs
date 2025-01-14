using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO.Genre;
using DataModels.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenreRepository genreRepository;

        public GenresController(IMapper mapper, IGenreRepository genreRepository)
        {
            this.mapper = mapper;
            this.genreRepository = genreRepository;
        }

        // CREATE Genre - Post: api/genre
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGenreRequestDto addGenreRequestDto)
        {
            // Map DTO to Domain
            var genreDomainModel = mapper.Map<GenreModel>(addGenreRequestDto);

            await genreRepository.CreateAsync(genreDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<GenreDto>(genreDomainModel));
        }

        // GET Genre
        // GET: /api/genres
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genreDomainModel = await genreRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<GenreDto>>(genreDomainModel));
        }

        // Get Genre By Id
        // GET; /api/genres/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genreDomainModel = await genreRepository.GetByIdAsync(id);

            if (genreDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(mapper.Map<GenreDto>(genreDomainModel));
        }

        // UPDATE Genre - PUT: /api/Genre/{}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreRequestDto updateGenreRequestDto)
        {
            // Map DTO to Domain
            var genreDomainModel = mapper.Map<GenreModel>(updateGenreRequestDto);

            genreDomainModel = await genreRepository.UpdateAsync(id, genreDomainModel);
            
            if (genreDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<GenreDto>(genreDomainModel));
        }

        // DELETE Genre - DELETE: /api/seat/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedGenre = await genreRepository.DeleteAsync(id);
            
            if (deletedGenre == null)
            {
                return NotFound();
            }

            // Map domain to DTO
            return Ok(mapper.Map<GenreDto>(deletedGenre));
        }
    }
}
