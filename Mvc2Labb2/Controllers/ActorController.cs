using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Data;
using Mvc2Labb2.Data.Paging;
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
        public async Task<IActionResult> Index(string propertyName, OrderByType orderBy, int currentPage = 1,int pageSize=25)
        {

            var actors = await _repository.Actor.GetAllActorsOrderByAsync(propertyName, orderBy).GetPaged(currentPage, pageSize).ConfigureAwait(false);
            var viewModel = new ListActorsViewModel()
            {
                Items = _mapper.Map<IEnumerable<ListActorsViewModel.ActorViewModel>>(actors.Results),
                OrderByViewModel =
                {
                    CurrentPropertyName = propertyName,
                    OrderBy = orderBy
                },
                PagingViewModel =
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize ,
                    LastPage = actors.PageCount
                }
            };

            return View(viewModel);
        }

        public async Task<IActionResult> MovieActors(int id)
        {
            var actors = await _repository.Actor.GetActorsByFilmIdAsync(id).ToListAsync().ConfigureAwait(false);
            var viewModel = new ListActorsViewModel
            {
                Items = _mapper.Map<IEnumerable<ListActorsViewModel.ActorViewModel>>(actors)
            };
            return View("Index", viewModel);
        }
    }
}