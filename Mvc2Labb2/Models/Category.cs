using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc2Labb2.Models
{
    [Table("category")]
    public sealed partial class Category
    {
        public Category()
        {
            FilmCategory = new HashSet<FilmCategory>();
        }

        [Key]
        [Column("category_id")]
        public byte CategoryId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [InverseProperty("Category")]
        public ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
