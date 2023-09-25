using TI_NET_2023_DemoASP.Models.DTOs;
using TI_NET_2023_DemoASP.Models.Entities;

namespace TI_NET_2023_DemoASP.Mappers
{
    public static class MovieMappers
    {
        public static MovieShortDTO toDTO(this Movie movie)
        {
            return new MovieShortDTO(movie.Id, movie.Title);
        }

        public static Movie ToEntity(this MovieFormDTO movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
            };
        }

        public static MovieFormDTO toForm(this Movie movie)
        {
            return new MovieFormDTO()
            {
                Title = movie.Title,
                Description = movie.Description,
            };
        }
    }
}
