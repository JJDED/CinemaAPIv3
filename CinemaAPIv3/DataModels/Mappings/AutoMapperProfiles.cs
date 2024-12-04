using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO;

namespace Cinema.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Users
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            // PostalCode
            CreateMap<PostalCode, PostalCodeDto>().ReverseMap();

            // Genre
            CreateMap<Genre, GenreDto>().ReverseMap();

            // Movie
            CreateMap<Movie, MovieDto>().ReverseMap();

            // Address
            CreateMap<UpdateAddressRequestDto, Address>().ReverseMap();
            CreateMap<AddAddressRequestDto, Address>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
