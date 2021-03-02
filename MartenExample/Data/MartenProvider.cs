using Marten;
using Marten.Services;
using MartenExample.Interfaces;
using MartenExample.Models;
using MartenExample.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Data
{
    public class MartenProvider : IExampleDataProvider
    {

        private DocumentStore _store { get; }

        public MartenProvider(string connectionString)
        {
            _store = DocumentStore.For(x =>
            {
                x.Connection(connectionString);
                x.Serializer(new JsonNetSerializer { EnumStorage = EnumStorage.AsInteger });

                x.Schema.For<Order>().ForeignKey<Customer>(y => y.CustomerId);

                //Add Email Column
                x.Schema.For<Customer>().Duplicate(x => x.Email, pgType: "varchar(100)", notNull: true);

                x.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
            });
        }        

        public Guid SaveCustomer(Customer item)
        {          
            try
            {
                using (var session = _store.LightweightSession())
                {
                    session.Store(item);
                    session.SaveChanges();
                }

                return item.Id;

            }
            catch (Exception ex)
            {
                return default(Guid);

            }
        }

        public Guid SaveOrder(Order item)
        {
            try
            {
                using (var session = _store.LightweightSession())
                {
                    session.Store(item);
                    session.SaveChanges();
                }

                return item.Id;

            }
            catch (Exception ex)
            {
                return default(Guid);

            }
        }

        public Order GetOrderById(Guid id)
        {
            Order existing;

            try
            {
                using (var session = _store.QuerySession())
                {
                    existing = session.Load<Order>(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return existing;
        }

        public CustomerView GetCustomerView(Guid id)
        {
            CustomerView result = new CustomerView();

            try
            {
                using (var session = _store.QuerySession())
                {
                    result.customer = session.Load<Customer>(id);
                    result.orders = session.Query<Order>().Where(x => x.CustomerId == id).ToList();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }

        public OrderView GetOrderView(Guid id)
        {
            Customer customer = new Customer();
            Order order;
            OrderView result = new OrderView();

            try
            {
                using (var session = _store.QuerySession())
                {
                    order = session.Query<Order>()
                        .Include<Customer>(x => x.CustomerId, x => customer = x)
                        .Where(x => x.Id == id)
                        .Single();
                }

                result.customer = customer;
                result.order = order;
            }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }

        public List<Customer> GetAllCustomers(int skipCount = 0, int takeCount = 100)
        {
            List<Customer> customers = new List<Customer>();

            using(var session = _store.QuerySession())
            {
                customers = session.Query<Customer>().Skip(skipCount).Take(takeCount).ToList();
            }

            return customers;
        }

        public List<T> GetAllItems<T>()
        {
            //List<T> existing = new List<T>();

            try
            {
                using (var session = _store.QuerySession())
                {
                    return session.Query<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            //return existing;
        }

        public bool BulkInsert<T>(List<T> items)
        {
            try
            {
                _store.BulkInsert<T>(items, BulkInsertMode.InsertsOnly, 500);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool CleanHouse()
        {
            try
            {
                using (var session = _store.LightweightSession())
                {
                    session.DeleteWhere<Order>(x => 1 == 1);
                    session.DeleteWhere<Customer>(x => 1 == 1);
                    session.DeleteWhere<Product>(x => 1 == 1);

                    session.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
