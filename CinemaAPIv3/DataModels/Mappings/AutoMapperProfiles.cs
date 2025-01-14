using AutoMapper;
using DataModels.Models.Domain;
using DataModels.Models.DTO.Address;
using DataModels.Models.DTO.Genre;
using DataModels.Models.DTO.Hall;
using DataModels.Models.DTO.Movie;
using DataModels.Models.DTO.PostalCode;
using DataModels.Models.DTO.Seat;
using DataModels.Models.DTO.Showtime;
using DataModels.Models.DTO.Theater;
using DataModels.Models.DTO.Ticket;
using DataModels.Models.DTO.User;

namespace Cinema.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            // Address
            CreateMap<AddressModel, AddAddressRequestDto>().ReverseMap();
            CreateMap<AddressModel, AddressDto>().ReverseMap();
            CreateMap<AddressModel, UpdateAddressRequestDto>().ReverseMap();

            // Genre
            //CreateMap<GenreModel, AddGenreRequestDto>().ReverseMap();
            //CreateMap<GenreModel, GenreDto>().ReverseMap();
            //CreateMap<GenreModel, UpdateGenreRequestDto>().ReverseMap();

            CreateMap<GenreModel, AddGenreRequestDto>().ReverseMap();
            CreateMap<GenreModel, GenreDto>().ReverseMap();
            CreateMap<GenreModel, UpdateGenreRequestDto>().ReverseMap();

            // Hall
            CreateMap<HallModel, AddHallRequestDto>().ReverseMap();
            CreateMap<HallModel, HallDto>().ReverseMap();
            CreateMap<HallModel, UpdateHallRequestDto>().ReverseMap();

            // Movie
            //CreateMap<MovieModel, AddMovieRequestDto>().ReverseMap()
            //    .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src =>
            //   src.GenreIds.Select(id => new MovieGenre { GenreId = id })));

            //CreateMap<MovieModel, MovieDto>()
            //    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src =>
            //        src.MovieGenres.Select(mg => mg.Genre))).ReverseMap();

            CreateMap<MovieModel, AddMovieRequestDto>().ReverseMap()
            .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src =>
                src.GenreIds.Select(id => new MovieGenre { GenreId = id })));

            CreateMap<MovieModel, MovieDto>().ForMember(dest => dest.Genres, opt => opt.MapFrom(src =>
                src.MovieGenres.Select(mg => mg.Genre))).ReverseMap();
            CreateMap<MovieModel, UpdateMovieRequestDto>().ReverseMap();

            // PostalCode
            CreateMap<PostalCodeModel, AddPostalCodeRequestDto>().ReverseMap();
            CreateMap<PostalCodeModel, PostalCodeDto>().ReverseMap();
            CreateMap<PostalCodeModel, UpdatePostalCodeRequestDto>().ReverseMap();

            // Seat
            CreateMap<SeatModel, AddSeatRequestDto>().ReverseMap();
            CreateMap<SeatModel, SeatDto>().ReverseMap();
            CreateMap<SeatModel, UpdateSeatRequestDto>().ReverseMap();

            // Showtimes
            CreateMap<ShowtimesModel, AddShowtimeRequestDto>().ReverseMap();
            CreateMap<ShowtimesModel, ShowtimesDto>().ReverseMap();
            CreateMap<ShowtimesModel, UpdateShowtimesRequestDto>().ReverseMap();

            // Theater
            CreateMap<TheaterModel, AddTheaterRequestDto>().ReverseMap();
            CreateMap<TheaterModel, TheaterDto>().ReverseMap();
            CreateMap<TheaterModel, UpdateTheaterRequestDto>().ReverseMap();

            // Tickets
            CreateMap<TicketsModel, AddTicketRequestDto>().ReverseMap();
            CreateMap<TicketsModel, TicketsDto>().ReverseMap();
            CreateMap<TicketsModel, UpdateTicketRequestDto>().ReverseMap();

            // Users
            CreateMap<UserModel, AddUserRequestDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UpdateUserRequestDto>().ReverseMap();

        }
    }
}
