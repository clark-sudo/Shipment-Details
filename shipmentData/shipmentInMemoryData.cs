using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace shipmentData
{
    public class savedDataInMemory : iShipmentData
    {
        public List<Shipments> data1 = new List<Shipments>();

        public savedDataInMemory()
        {
            Shipments shipments = new Shipments
            {
                ShipmentId = Guid.NewGuid(),
                //Buyer = "clark",
                //Number = "987 654 3210",
                //Address = "santolan",
                //Store = "E-commerce Store",
                Product = "Blueberry",
                Price = 19999,
                Quantity = 9,
                Fee = 30
            };
            data1.Add(shipments);
        }
        public void Add(Shipments shipments)
        {
            data1.Add(shipments);
        }
        public Shipments? GetById(Guid id)
        {
            return data1.FirstOrDefault(a => a.ShipmentId == id);
        }
        public Shipments? GetByProduct(string product)
        {
            return data1.FirstOrDefault(a => a.Product == product);
        }
        public void Edit(Shipments shipment)
        {

            var existingOrders = GetById(shipment.ShipmentId);

            if (existingOrders != null)
            {
                existingOrders.Product = shipment.Product;
                existingOrders.Price = shipment.Price;
                existingOrders.Quantity = shipment.Quantity;
            }
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public bool ProductExists(string product)
        {
            return data1.Any(a => a.Product == product);
        }
        public List<Shipments> GetShipments()
        {
            return data1;
        }
    }
}
