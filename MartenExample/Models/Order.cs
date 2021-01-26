using Marten.Schema;
using MartenExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        //[ForeignKey(typeof(Customer))]
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Items { get; set; }
        public decimal Total { get
            {
                decimal total = 0;

                foreach(Product item in Items)
                {
                    total += item.price;
                }

                return total;
            }            
        }
    }
}
