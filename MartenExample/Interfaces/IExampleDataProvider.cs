using MartenExample.Models;
using MartenExample.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Interfaces
{
    public interface IExampleDataProvider
    {
        public Guid SaveCustomer(Customer item);

        public Guid SaveOrder(Order item);

        public CustomerView GetCustomerView(Guid id);

        public OrderView GetOrderView(Guid id);        

        public Order GetOrderById(Guid id);

        public List<T> GetAllItems<T>();

        public bool BulkInsert<T>(List<T> items);

        public bool CleanHouse();
        
    }
}
