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

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.ReadAll();
        }
    }
}
