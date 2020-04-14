using System.Collections.Generic;
using Mvc2Labb2.Data;

namespace Mvc2Labb2.ViewModels
{
    public class ListMovieViewModel
    {
        public IEnumerable<MovieViewModel> Items { get; set; }
        public OrderByType OrderBy { get; set; }
        public class MovieViewModel
        {
            public int FilmId { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
        }
    }
}