using Microsoft.AspNetCore.Mvc;
using TI_NET_2023_DemoASP.Mappers;
using TI_NET_2023_DemoASP.Models.DTOs;
using TI_NET_2023_DemoASP.Models.Entities;
using TI_NET_2023_DemoASP.Services;

namespace TI_NET_2023_DemoASP.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieShortDTO> movies = _movieService.GetAll().Select(m => m.toDTO());
            return View(movies.ToList());
        }
    }
}
