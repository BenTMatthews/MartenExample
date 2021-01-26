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
    public class MartenProvider
    {

        private DocumentStore _store { get; }

        public MartenProvider(string connectionString)
        {
            _store = DocumentStore.For(x =>
            {
                x.Connection(connectionString);
                x.Serializer(new JsonNetSerializer { EnumStorage = EnumStorage.AsInteger });

                x.Schema.For<Order>().ForeignKey<Customer>(y => y.CustomerId);

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


        public CustomerView GetCustomerAndOrders(Guid id)
        {
            Customer existing;
            List<Order> custOrders;
            CustomerView result = new CustomerView();

            try
            {
                using (var session = _store.QuerySession())
                {
                    existing = session.Load<Customer>(id);
                    custOrders = session.Query<Order>().Where(x => x.CustomerId == id).ToList();
                }

                result.customer = existing;
                result.orders = custOrders;
            }
            catch (Exception ex)
            {
                return null;
            }

            return result;
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

        public List<T> GetAllItems<T>()
        {
            List<T> existing = new List<T>();

            try
            {
                using (var session = _store.QuerySession())
                {
                    existing = session.Query<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return existing;
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
