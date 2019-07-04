using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    // no INorthwindDb beacuse of string ID -> has it's own repo
    public class CustomerDto
    {
        public CustomerDto()
        {
            this.Orders = new Collection<OrderDto>();
        }

        [Key]
        public string CustomerId { get; set; }
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
        public ICollection<OrderDto> Orders { get; set; }
    }
}
