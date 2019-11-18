using MovieStore.Interfaces;
using MovieStore.Models;
using MovieStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Repositories
{
    public class MovieRespository : IRespository<Movie>, IMovieExample
    {
        private ApplicationDbContext _dbContext;

        public MovieRespository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Movie movie)
        {
            if (movie != null)
            {
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
            }
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie Update(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            return movie ?? throw new ArgumentNullException(nameof(movie));
        }

        public void Update(Movie movie)
        {
            _dbContext.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public (string, string, DateTime) GetMovieDetailsById(int id)
        {
            var movies = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            string MovieName = movies.MovieName;
            string DirectorName = movies.DirectorName;
            DateTime ReleaseDate = movies.ReleaseDate;

            return (MovieName, DirectorName, ReleaseDate);
        }
    }
}
