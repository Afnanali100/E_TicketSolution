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
    }
}
