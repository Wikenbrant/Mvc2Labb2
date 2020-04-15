using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc2Labb2.Data;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Controllers
{
    public class ActorController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ActorController(IRepositoryWrapper repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string orderOnProperty, OrderByType orderByFirstName, OrderByType orderByLastName)
        {
            var orderBy = orderByFirstName == OrderByType.None ? orderByLastName : orderByFirstName;
            var actors = await _repository.Actor.GetAllActorsOrderByAsync(orderOnProperty, orderBy).ConfigureAwait(false);
            var viewModel = new ListActorsViewModel
            {
                Items = _mapper.Map<IEnumerable<ListActorsViewModel.ActorViewModel>>(actors),
                OrderByFirstName = orderByFirstName ,
                OrderByLastName = orderByLastName 
            };

            return View(viewModel);
        }

        public async Task<IActionResult> MovieActors(int id)
        {
            var actors = await _repository.Actor.GetActorsByFilmIdAsync(id).ConfigureAwait(false);
            var viewModel = new ListActorsViewModel
            {
                Items = _mapper.Map<IEnumerable<ListActorsViewModel.ActorViewModel>>(actors),
                OrderByFirstName = OrderByType.Asc,
                OrderByLastName = OrderByType.None
            };
            return View("Index", viewModel);
        }
    }
}