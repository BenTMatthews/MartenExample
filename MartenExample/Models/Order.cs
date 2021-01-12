using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Models
{
    public class Order
    {
        public Guid id { get; set; }
        public Guid customerId { get; set; }
        public DateTime orderDate { get; set; }
        public List<Item> items { get; set; }
        public decimal total { get
            {
                decimal total = 0;

                foreach(Item item in items)
                {
                    total += item.price;
                }

                return total;
            }            
        }
    }
}
