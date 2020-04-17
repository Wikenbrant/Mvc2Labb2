using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc2Labb2.Models
{
    [Table("store")]
    public sealed partial class Store
    {
        public Store()
        {
            Customer = new HashSet<Customer>();
            Inventory = new HashSet<Inventory>();
            Staff = new HashSet<Staff>();
        }

        [Key]
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("manager_staff_id")]
        public byte ManagerStaffId { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Store")]
        public Address Address { get; set; }
        [ForeignKey(nameof(ManagerStaffId))]
        [InverseProperty("StoreNavigation")]
        public Staff ManagerStaff { get; set; }
        [InverseProperty("Store")]
        public ICollection<Customer> Customer { get; set; }
        [InverseProperty("Store")]
        public ICollection<Inventory> Inventory { get; set; }
        [InverseProperty("Store")]
        public ICollection<Staff> Staff { get; set; }
    }
}
