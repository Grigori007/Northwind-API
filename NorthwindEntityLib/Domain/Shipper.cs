using Newtonsoft.Json;
using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Shipper : IBaseEntity
    {
        public Shipper()
        {
            this.Orders = new Collection<Order>();
        }

        [Required]
        public int ShipperId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        [JsonIgnore]
        public dynamic EntityId => ShipperId;
    }
}
