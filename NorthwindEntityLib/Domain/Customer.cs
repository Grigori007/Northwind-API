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
        public string CustomerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        [NotMapped]
        public dynamic EntityId => CustomerId;
    }
}
