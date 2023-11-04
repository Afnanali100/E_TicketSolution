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
    public class ActorController : Controller
    {
      //  private readonly IGenericRepository<Actor> genericRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ActorController(IUnitOfWork unitOfWork,IMapper mapper)
        {
           // this.genericRepo = genericRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var  actors= await unitOfWork.ActorgenericRepository.GetAllAsync();

            var MappedActors =  mapper.Map<IEnumerable<Actor>,IEnumerable<ActorViewModel>>(actors);
            return View(MappedActors);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel model)
        {
            if(ModelState.IsValid)
            {
                var mappedactor=mapper.Map<ActorViewModel,Actor>(model);
               await unitOfWork.ActorgenericRepository.AddAsync(mappedactor);
             await unitOfWork.Complete(); 
        
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id,string name="Details")
        {
            if (id == null)
                return BadRequest();
            var actor =await unitOfWork.ActorgenericRepository.GetById(id.Value);
            if (actor == null)
                return NotFound();

            var mappedactor =  mapper.Map<Actor, ActorViewModel>(actor);
            return View(name,mappedactor);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(ActorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedactor = mapper.Map<ActorViewModel, Actor>(model);
                 unitOfWork.ActorgenericRepository.Update(mappedactor);
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

        public async Task<IActionResult>Delete(ActorViewModel model)
        {
            
           if(model is not null)
            {
                var mappedactor=mapper.Map<ActorViewModel,Actor>(model);
                unitOfWork.ActorgenericRepository.Delete(mappedactor);
               await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

    }
}
