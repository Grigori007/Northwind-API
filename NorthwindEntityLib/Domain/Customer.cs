using Newtonsoft.Json;
using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Customer : IBaseEntity
    {
        public Customer()
        {
            this.Orders = new Collection<Order>();
        }

        [Required]
        [StringLength(5, ErrorMessage = "Maximum length is 5 characters!")]
        public string CustomerId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters!")]
        public string CompanyName { get; set; }
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters!")]
        public string ContactName { get; set; }
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters!")]
        public string ContactTitle { get; set; }
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
        public string Phone { get; set; }
        [StringLength(24, ErrorMessage = "Maximum length is 24 characters!")]
        public string Fax { get; set; }
        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        [JsonIgnore]
        public dynamic EntityId => CustomerId;
    }
}
