using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc2Labb2.Models
{
    [Table("city")]
    public sealed partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        [Key]
        [Column("city_id")]
        public int CityId { get; set; }
        [Required]
        [Column("city")]
        [StringLength(50)]
        public string City1 { get; set; }
        [Column("country_id")]
        public short CountryId { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("City")]
        public Country Country { get; set; }
        [InverseProperty("City")]
        public ICollection<Address> Address { get; set; }
    }
}
