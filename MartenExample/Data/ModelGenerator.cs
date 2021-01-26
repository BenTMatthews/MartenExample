using MartenExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Data
{
    public class ModelGenerator
    {
        private Random _random = new Random();

        public ModelGenerator()
        {

        }
        
        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Id = 1001, name = "Probe", price = Math.Round(GenerateRandomDecimal(45, 55), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1002, name = "Zealot", price = Math.Round(GenerateRandomDecimal(90, 110), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1003, name = "Stalker", price = Math.Round(GenerateRandomDecimal(115, 135), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1004, name = "Adept", price = Math.Round(GenerateRandomDecimal(90, 110), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1005, name = "Immortal", price = Math.Round(GenerateRandomDecimal(200, 300), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1006, name = "Colossus", price = Math.Round(GenerateRandomDecimal(250, 350), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1007, name = "Disruptor", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1008, name = "Phoenix", price = Math.Round(GenerateRandomDecimal(125, 175), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1009, name = "Void Ray", price = Math.Round(GenerateRandomDecimal(150, 250), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1010, name = "Oracle", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1011, name = "Tempest", price = Math.Round(GenerateRandomDecimal(175, 325), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1012, name = "Carrier", price = Math.Round(GenerateRandomDecimal(275, 475), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1013, name = "Mothership", price = Math.Round(GenerateRandomDecimal(350, 450), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1014, name = "High Templar", price = Math.Round(GenerateRandomDecimal(20, 150), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1015, name = "Dark Templar", price = Math.Round(GenerateRandomDecimal(120, 130), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1016, name = "Observer", price = Math.Round(GenerateRandomDecimal(15, 75), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1017, name = "Warp Prism", price = Math.Round(GenerateRandomDecimal(245, 255), 2), quantity = _random.Next(0, 200) });

            products.Add(new Product { Id = 1101, name = "SCV", price = Math.Round(GenerateRandomDecimal(45, 55), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1102, name = "Marine", price = Math.Round(GenerateRandomDecimal(45, 55), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1103, name = "Marauder", price = Math.Round(GenerateRandomDecimal(95, 105), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1104, name = "Reaper", price = Math.Round(GenerateRandomDecimal(45, 55), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1105, name = "Ghost", price = Math.Round(GenerateRandomDecimal(150, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1106, name = "Hellion", price = Math.Round(GenerateRandomDecimal(75, 125), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1107, name = "Widow Mine", price = Math.Round(GenerateRandomDecimal(70, 80), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1108, name = "Siege Tank", price = Math.Round(GenerateRandomDecimal(115, 185), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1109, name = "Cyclone", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1110, name = "Thor", price = Math.Round(GenerateRandomDecimal(250, 350), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1111, name = "Viking", price = Math.Round(GenerateRandomDecimal(125, 175), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1112, name = "Medivac", price = Math.Round(GenerateRandomDecimal(50, 150), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1113, name = "Liberator ", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1114, name = "Banshee", price = Math.Round(GenerateRandomDecimal(125, 175), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1115, name = "Raven", price = Math.Round(GenerateRandomDecimal(50, 250), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1116, name = "Battlecruiser", price = Math.Round(GenerateRandomDecimal(300, 500), 2), quantity = _random.Next(0, 200) });

            products.Add(new Product { Id = 1201, name = "Drone", price = Math.Round(GenerateRandomDecimal(45, 55), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1202, name = "Queen", price = Math.Round(GenerateRandomDecimal(125, 175), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1203, name = "Zergling", price = Math.Round(GenerateRandomDecimal(20, 30), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1204, name = "Baneling", price = Math.Round(GenerateRandomDecimal(20, 30), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1205, name = "Roach", price = Math.Round(GenerateRandomDecimal(50, 100), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1206, name = "Ravager", price = Math.Round(GenerateRandomDecimal(75, 125), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1207, name = "Hydralisk", price = Math.Round(GenerateRandomDecimal(75, 125), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1208, name = "Lurker", price = Math.Round(GenerateRandomDecimal(115, 185), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1209, name = "Infestor", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1210, name = "Swarm Host", price = Math.Round(GenerateRandomDecimal(75, 125), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1211, name = "Ultralisk", price = Math.Round(GenerateRandomDecimal(200, 400), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1212, name = "Overlord", price = Math.Round(GenerateRandomDecimal(50, 150), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1213, name = "Overseer ", price = Math.Round(GenerateRandomDecimal(75, 125), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1214, name = "Mutalisk", price = Math.Round(GenerateRandomDecimal(50, 150), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1215, name = "Corruptor", price = Math.Round(GenerateRandomDecimal(100, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1216, name = "Viper", price = Math.Round(GenerateRandomDecimal(50, 200), 2), quantity = _random.Next(0, 200) });
            products.Add(new Product { Id = 1217, name = "Brood Lord", price = Math.Round(GenerateRandomDecimal(250, 400), 2), quantity = _random.Next(0, 200) });

            return products;
        }


        public List<Customer> GenerateCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Dan Rydell" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Casey McCall" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Dana Whitaker" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Jeremy Goodwin" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Natalie Hurley" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Isaac Jaffe" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Rebecca Wells" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Sally Sasser" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Sam Donovan" });
            customers.Add(new Customer { Id = Guid.NewGuid(), Name = "Abby Jacobs" });

            return customers;
        }

        public List<Order> GenerateOrders(List<Guid> custIds,  List<Product> prods)
        {
            List<Order> orders = new List<Order>();

            foreach (Guid custId in custIds)
            {

                int orderCount = _random.Next(1, 50);

                for (int i = 0; i < orderCount; i++)
                {
                    Order newOrder = new Order();

                    newOrder.CustomerId = custId;
                    newOrder.Id = Guid.NewGuid();
                    newOrder.OrderDate = GetRandomDay();

                    int productCount = _random.Next(1, 100);
                    List<Product> orderProducts = new List<Product>(productCount);

                    for (int j = 0; j < productCount; j++)
                    {
                        int priceShift = _random.Next(-10, 10);
                        Product prod = prods[_random.Next(0, prods.Count)];

                        if ((orderProducts.Where(existingProd => existingProd.Id == prod.Id).FirstOrDefault()) == null)
                        {
                            prod.price = Math.Round(prod.price * GenerateRandomDecimal(.9, 1.1), 2);
                            prod.quantity = _random.Next(1, 30);
                            orderProducts.Add(prod);
                        }

                    }

                    newOrder.Items = orderProducts;

                    orders.Add(newOrder);
                }
            }

            return orders;
        }

        private decimal GenerateRandomDecimal(double min, double max)
        {
                var next = _random.NextDouble();

                return (decimal)(min + (next * (max - min)));
            
        }

        private DateTime GetRandomDay()
        {
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }
    }
}
