using DataModels.Data;
using DataModels.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public class SQLMovieRepository : IMovieRepository
    {
        private readonly MyDbContext dbContext;

        public SQLMovieRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<MovieModel> CreateAsync(MovieModel movie)
        {

            var genres = await dbContext.Genres.Where(g => movie.MovieGenres.Select(mg => mg.GenreId).Contains(g.Id)).ToListAsync();
            movie.MovieGenres = genres.Select(g => new MovieGenre { MovieId = movie.Id, GenreId = g.Id }).ToList();

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();


            //string newMovieObject = new string();
            //MovieModel movieModelObject = new MovieModel();
            //movieModelObject.Title = movie.Title;
            //movieModelObject.DurationMinutes = movie.DurationMinutes;
            //movieModelObject.ReleaseYear = movie.ReleaseYear;

            //await dbContext.SaveChangesAsync();

            //GenreModel genreModelObject = new GenreModel();

            //dbContext.Movies.FirstOrDefaultAsync(x => x.GenreId == movie.Id);

            return movie;
        }

        public async Task<MovieModel?> DeleteAsync(int id)
        {
            var existingMovie = await dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            // måske skal vi slette genre?
            //var existingMovie = await dbContext.Movies.Include(m => m.Genres).FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie == null)
            {
                return null;
            }

            dbContext.Movies.Remove(existingMovie); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingMovie;
        }

        public async Task<List<MovieModel>> GetAllAsync()
        {
            return await dbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .ToListAsync();
        }

        public async Task<MovieModel?> GetByIdAsync(int id)
        {
            return await dbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MovieModel?> UpdateAsync(int id, MovieModel movie)
        {
            var existingMovie = await dbContext.Movies.Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre).FirstOrDefaultAsync(x => x.Id == id);
            if (existingMovie == null)
            {
                return null;
            }

            var genres = await dbContext.Genres.Where(g => movie.MovieGenres.Select(mg => mg.GenreId).Contains(g.Id)).ToListAsync();
            var movieGenres = genres.Select(g => new MovieGenre { MovieId = existingMovie.Id, GenreId = g.Id }).ToList();
            existingMovie.Title = movie.Title;
            existingMovie.DurationMinutes = movie.DurationMinutes;
            existingMovie.ReleaseYear = movie.ReleaseYear;
            existingMovie.MovieGenres = movieGenres;

            await dbContext.SaveChangesAsync();
            return existingMovie;
        }
    }
}
