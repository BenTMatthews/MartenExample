using MartenExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Views.ViewModel
{
    public class OrderView
    {
        public Customer customer { get; set; }
        public Order order { get; set; }
    }
}
