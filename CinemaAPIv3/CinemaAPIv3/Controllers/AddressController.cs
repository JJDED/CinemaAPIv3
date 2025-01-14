using AutoMapper;
using DataModels.Repositories;
using DataModels.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels.Models.DTO.Address;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepository;

        public AddressController(IMapper mapper, IAddressRepository addressRepository)
        {
            this.mapper = mapper;
            this.addressRepository = addressRepository;
        }

        // CREATE Address - POST: /api/address
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAddressRequestDto addAddressRequestDto)
        {
            // Map DTO to Domain
            var addressDomainModel = mapper.Map<AddressModel>(addAddressRequestDto);

            await addressRepository.CreateAsync(addressDomainModel);

            // Map Domain to DTO
            return Ok(mapper.Map<AddressDto>(addressDomainModel));
        }

        // GET ALL Address - GET: /api/address
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addressDomainModel = await addressRepository.GetAllAsync();

            // Map Domain to DTO
            return Ok(mapper.Map<List<AddressDto>>(addressDomainModel));
        }

        // GET BY ID Address - GET: /api/address/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addressDomainModel = await addressRepository.GetByIdAsync(id);

            if (addressDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain to DTO
            return Ok(mapper.Map<AddressDto>(addressDomainModel));
        }

        // UPDATE Address by Id - PUT: /api/address/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAddressRequestDto updateAddressRequestDto)
        {
            // Map DTO to Domain
            var addressDomainModel = mapper.Map<AddressModel>(updateAddressRequestDto);

            addressDomainModel = await addressRepository.UpdateAsync(id, addressDomainModel);

            if (addressDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
            return Ok(mapper.Map<AddressDto>(addressDomainModel));
        }

        // DELETE Address by Id - DELETE: /api/address/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedAddressDomainModel = await addressRepository.DeleteAsync(id);
            if (deletedAddressDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain to DTO
            return Ok(mapper.Map<AddressDto>(deletedAddressDomainModel));
        }
    }
}