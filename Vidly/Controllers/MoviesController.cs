using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Models.RandomMovieViewModels;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,  
                Customers = customers

            };
            return View(viewModel);
        }
        public IActionResult Index()
        {
            var movieList = GetMovies();
            return View(movieList);
        }

        [Route("movies/released/{year}/{month}")]
        public IActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public List<Movie> GetMovies()
        {
            var movieList = new List<Movie>
            {
                new Movie()
                {
                    Name = "Shrek"
                },
                new Movie()
                {
                    Name = "Wall-e"
                },

            };
            return movieList;
        }

    }
}