using TI_NET_2023_DemoASP.Models.Entities;
using TI_NET_2023_DemoASP.Repositories;

namespace TI_NET_2023_DemoASP.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie Add(Movie movie)
        {
            if (movie.Title.Trim() == "")
            {
                throw new Exception("Title is required");
            }
            return _movieRepository.Create(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.ReadAll();
        }

        public Movie GetOne(int id)
        {
            return _movieRepository.ReadOne(id);
        }

        public bool Update(int id, Movie movie)
        {
            return _movieRepository.Update(id, movie);
        }

        public bool Delete(int id)
        {
            return _movieRepository.Delete(id);
        }
    }
}
