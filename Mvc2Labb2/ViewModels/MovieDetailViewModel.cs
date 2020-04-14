using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

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
