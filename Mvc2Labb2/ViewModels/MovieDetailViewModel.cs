using System;

namespace Mvc2Labb2.ViewModels
{
    public class MovieDetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
