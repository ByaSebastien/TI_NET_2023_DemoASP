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

        public IActionResult Details(int id)
        {
            Movie movie = _movieService.GetOne(id);
            return View(movie);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieFormDTO movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            _movieService.Add(movie.ToEntity());
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            TempData["movieId"] = id;
            TempData["wantToUpdate"] = true;
            Movie movie = _movieService.GetOne(id);
            return View("Add", movie.toForm());
        }

        [HttpPost]
        public IActionResult Update(MovieFormDTO movie)
        {
            int id = 0;
            if (TempData["movieId"] != null)
            {
                id = TempData["movieId"] is int i ? i : 0;
            }
            if(id == 0)
            {
                return RedirectToAction("Index","Home");
            }
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            _movieService.Update(id, movie.ToEntity());
            TempData.Remove("movieId");
            TempData.Remove("wantToUpdate");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
