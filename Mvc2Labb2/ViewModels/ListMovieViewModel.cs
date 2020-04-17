using System.Collections.Generic;
using Mvc2Labb2.Data;

namespace Mvc2Labb2.ViewModels
{
    public class ListMovieViewModel
    {
        public IEnumerable<MovieViewModel> Items { get; set; }
        public OrderByViewModel OrderByViewModel { get; set; } = new OrderByViewModel();
        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();
        public class MovieViewModel
        {
            public int FilmId { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
        }

    }
}