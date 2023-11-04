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
    public class ProducerController : Controller
    {
       // private readonly IGenericRepository<Producer> genericRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProducerController(IGenericRepository<Producer> genericRepo,IMapper mapper,IUnitOfWork unitOfWork)
        {

           // this.genericRepo = genericRepo;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            var producers = await unitOfWork.ProducergenericRepository.GetAllAsync();
            var MappedProducers = mapper.Map<IEnumerable<Producer>, IEnumerable<ProducerViewModel>>(producers);
            return View(MappedProducers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedProducer = mapper.Map<ProducerViewModel, Producer>(model);
                await unitOfWork.ProducergenericRepository.AddAsync(mappedProducer);
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
            var producer = await unitOfWork.ProducergenericRepository.GetById(id.Value);
            if (producer == null)
                return NotFound();

            var mappedProducer = mapper.Map<Producer, ProducerViewModel>(producer);
            return View(name, mappedProducer);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(ProducerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedProducer = mapper.Map<ProducerViewModel, Producer>(model);
                unitOfWork.ProducergenericRepository.Update(mappedProducer);
                await unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(ProducerViewModel model)
        {

            if (model is not null)
            {
                var mappedProducer = mapper.Map<ProducerViewModel, Producer>(model);
                unitOfWork.ProducergenericRepository.Delete(mappedProducer);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }


    }
}
