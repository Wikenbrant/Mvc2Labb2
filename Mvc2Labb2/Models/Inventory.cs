﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc2Labb2.Models
{
    [Table("inventory")]
    public sealed partial class Inventory
    {
        public Inventory()
        {
            Rental = new HashSet<Rental>();
        }

        [Key]
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty("Inventory")]
        public Film Film { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Inventory")]
        public Store Store { get; set; }
        [InverseProperty("Inventory")]
        public ICollection<Rental> Rental { get; set; }
    }
}
