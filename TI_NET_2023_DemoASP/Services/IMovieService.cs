using TI_NET_2023_DemoASP.Models.Entities;

namespace TI_NET_2023_DemoASP.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
    }
}
