using AutoMapper;
using E_ticket.BLL.Interfaces;
using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using E_Ticket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticket.Controllers
{
    public class CinemaController : Controller
    {
      //  private readonly IGenericRepository<Cinema> genericRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CinemaController(IGenericRepository<Cinema> genericRepo,IMapper mapper,IUnitOfWork unitOfWork)
        {
         //   this.genericRepo = genericRepo;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            var cinemas = await unitOfWork.CinemagenericRepository.GetAllAsync();
            var MappedCineam = mapper.Map<IEnumerable<Cinema>,IEnumerable<CinemaViewModel>>(cinemas);
            return View(MappedCineam);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedCinema = mapper.Map<CinemaViewModel, Cinema>(model);
                await unitOfWork.CinemagenericRepository.AddAsync(mappedCinema);
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
            var Cinema = await unitOfWork.CinemagenericRepository.GetById(id.Value);
            if (Cinema == null)
                return NotFound();

            var mappedCinema = mapper.Map<Cinema, CinemaViewModel>(Cinema);
            return View(name, mappedCinema);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(CinemaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedCinema = mapper.Map<CinemaViewModel, Cinema>(model);
                unitOfWork.CinemagenericRepository.Update(mappedCinema);
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

        public async Task<IActionResult> Delete(CinemaViewModel model)
        {

            if (model is not null)
            {
                var mappedCinema = mapper.Map<CinemaViewModel, Cinema>(model);
                unitOfWork.CinemagenericRepository.Delete(mappedCinema);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }



    }
}
