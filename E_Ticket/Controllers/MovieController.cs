using AutoMapper;
using E_ticket.BLL.Interfaces;
using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using E_Ticket.BLL.Specification;
using E_Ticket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticket.Controllers
{
    public class MovieController : Controller
    {
     //   private readonly IGenericRepository<Movie> genericRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public MovieController(IGenericRepository<Movie> genericRepo,IMapper mapper,IUnitOfWork unitOfWork)
        {
          //  this.genericRepo = genericRepo;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            MovieSpecification spec=new MovieSpecification();
            var movies = await unitOfWork.MoviegenericRepository.GetAllAsyncBySpecification(spec);
          var  MappedMovies = mapper.Map<IEnumerable<Movie>,IEnumerable<MovieViewModel>>(movies);


            return View(MappedMovies);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedMovie = mapper.Map<MovieViewModel, Movie>(model);
                await unitOfWork.MoviegenericRepository.AddAsync(mappedMovie);
                await unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id, string name = "Details")
        {
            if (id == null)
                return BadRequest();
            var movie = await unitOfWork.MoviegenericRepository.GetById(id.Value);
            if (movie == null)
                return NotFound();

            var mappedMovie = mapper.Map<Movie, MovieViewModel>(movie);
            return View(name, mappedMovie);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedMovie = mapper.Map<MovieViewModel, Movie>(model);
                unitOfWork.MoviegenericRepository.Update(mappedMovie);
                await unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(MovieViewModel model)
        {

            if (model is not null)
            {
                var mappedMovie = mapper.Map<MovieViewModel, Movie>(model);
                unitOfWork.MoviegenericRepository.Delete(mappedMovie);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }



    }
}
