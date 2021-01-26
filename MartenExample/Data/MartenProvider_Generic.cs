using Marten;
using Marten.Services;
using MartenExample.Interfaces;
using MartenExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Data
{
    public class MartenProvider_Generic
    {

        private DocumentStore _store { get; }

        public MartenProvider_Generic(string connectionString)
        {
            _store = DocumentStore.For(x =>
            {
                x.Connection(connectionString);
                x.Serializer(new JsonNetSerializer { EnumStorage = EnumStorage.AsInteger });

                x.Schema.For<Order>().ForeignKey<Customer>(y => y.CustomerId);

                x.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
            });
        }        

        public bool SaveItem<T>(MartenInterface<T> item)
        {          
            try
            {
                using (var session = _store.LightweightSession())
                {
                    session.Store(item);
                    session.SaveChanges();
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        //Assumes all IDs are guids. If using Ints, need to break out the function
        public T GetItemById<T>(Guid id) 
        {
            T existing;

            try
            {                
                using (var session = _store.QuerySession())
                {            
                    existing = session.Load<T>(id);
                }
            }
            catch (Exception ex)
            {
                return default(T);
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
                    session.Query<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return existing;
        }
    }
}
