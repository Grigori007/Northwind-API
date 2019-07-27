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
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters!")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters!")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters!")]
        public string Title { get; set; }
        [StringLength(25, ErrorMessage = "Maximum length is 25 characters!")]
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(60, ErrorMessage = "Maximum length is 60 characters!")]
        public string Address { get; set; }
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters!")]
        public string City { get; set; }
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters!")]
        public string Region { get; set; }
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters!")]
        public string PostalCode { get; set; }
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters!")]
        public string Country { get; set; }
        [StringLength(24, ErrorMessage = "Maximum length is 24 characters!")]
        public string HomePhone { get; set; }
        [StringLength(4, ErrorMessage = "Maximum length is 4 characters!")]
        public string Extension { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Manager")]
        public int? ReportsTo { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        [JsonIgnore]
        public dynamic EntityId => EmployeeId;
    }
}
