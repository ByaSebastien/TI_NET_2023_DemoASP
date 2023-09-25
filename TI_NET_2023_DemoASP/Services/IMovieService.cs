using TI_NET_2023_DemoASP.Models.Entities;

namespace TI_NET_2023_DemoASP.Services
{
    public interface IMovieService
    {
        Movie Add(Movie movie);
        IEnumerable<Movie> GetAll();
        Movie GetOne(int id);
        bool Update(int id, Movie movie);

        bool Delete(int id);
    }
}
