using Newtonsoft.Json;
using NorthwindEntityLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Employee : IBaseEntity
    {
        public Employee()
        {
            this.Orders = new Collection<Order>();
        }

        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Manager")]
        public int? ReportsTo { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        [NotMapped]
        public dynamic EntityId => EmployeeId;
    }
}
