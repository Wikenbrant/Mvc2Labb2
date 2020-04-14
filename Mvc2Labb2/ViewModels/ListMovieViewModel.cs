using System.Collections.Generic;
using Mvc2Labb2.Data;

namespace Mvc2Labb2.ViewModels
{
    public class ListMovieViewModel
    {
        public IEnumerable<MovieViewModel> Items { get; set; }
        public OrderByType OrderByTitle { get; set; }
        public OrderByType OrderByReleaseYear { get; set; }
        public class MovieViewModel
        {
            public int FilmId { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
        }

    }
}