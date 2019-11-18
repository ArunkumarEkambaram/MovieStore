using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Interfaces;
using MovieStore.Models;
using MovieStore.ViewModel;
using System;

namespace MovieStore.Controllers
{

    public class MoviesController : Controller
    {
        private IRespository<Movie> _movieRespository;
        private readonly IMapper _mapper;
        private IMovieExample _movieExample;

        //DI - Constructor Injection
        public MoviesController(IRespository<Movie> movieRespository, IMapper mapper, IMovieExample movieExample)
        {
            _movieRespository = movieRespository;
            _mapper = mapper;
            _movieExample = movieExample;
        }

        // [Route("Movies/Index")]
        public IActionResult Index()
        {
            var movies = _movieRespository.GetAll();
            return View(movies);
        }

        // [Route("Movies/Details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _movieRespository.GetById(id);
            return View(movie);
        }

        // [Route("Movies/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Movies/CreateNew")]
        public IActionResult CreateNew(MovieViewModel movieView)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            //Movie movie = new Movie
            //{
            //    MovieName = movieView.MovieName,
            //    DirectorName = movieView.DirectorName,
            //    ReleaseDate = movieView.ReleaseDate
            //};
            Movie m = _mapper.Map<Movie>(movieView);

            _movieRespository.Add(m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieRespository.Update(id);
            //MovieViewModel viewModel = new MovieViewModel();
            //viewModel.Movie = movie;
            MovieViewModel viewModel = _mapper.Map<MovieViewModel>(movie);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel movieFromView)
        {
            //AutoMapper
            //Movie m = new Movie
            //{
            //    Id = movieFromView.Movie.Id,
            //    MovieName = movieFromView.Movie.MovieName,
            //    DirectorName = movieFromView.Movie.DirectorName,
            //    ReleaseDate = movieFromView.Movie.ReleaseDate
            //};           

            Movie m = _mapper.Map<Movie>(movieFromView);

            _movieRespository.Update(m);

            return RedirectToAction("Index");
        }

        public IActionResult GetMovieDetails(int id)
        {
            //var details = _movieExample.GetMovieDetailsById(id);
            //return Content($"Movie Name :{details.Item1}\nDirector Name :{details.Item2}\nRelease Date :{details.Item3}");

            //Tuples Deconstruction
            (string MovieName, string DirectorName, DateTime ReleaseDate) = _movieExample.GetMovieDetailsById(id);
            return Content($"Movie Name :{MovieName}\nDirector Name:{DirectorName}\nRelease Date :{ReleaseDate}");
        }
    }
}
