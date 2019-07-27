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
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters!")]
        public string CompanyName { get; set; }
        [StringLength(24, ErrorMessage = "Maximum length is 24 characters!")]
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        [JsonIgnore]
        public dynamic EntityId => ShipperId;
    }
}
