using shipmentModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace shipmentData
{
    public class savedDataInMemory : iShipmentData
    {
        public List<Shipment> data1 = new List<Shipment>();
        public List<Details> data2 = new List<Details>();
        public savedDataInMemory()
        {
            Shipment shipment = new Shipment { ShipmentId = Guid.NewGuid(), Buyer = "clark", Number = "987 654 3210", Address = "santolan" };
            data1.Add(shipment);
            Details details = new Details { Store = "E-commerce Store", Product = "Apple", Price = 99999999, Quantity = 9, Month = "December", Day = 20, Discount = "Free shipping", Fee = 30 };
            data2.Add(details);
        }
        public void Add(Shipment shipment)
        {
            data1.Add(shipment);
            //string number = "987 654 3210";
            //return number;
        }
        //public string getAddress()
        public Shipment? GetById(Guid id)
        {
            return data1.FirstOrDefault(a => a.ShipmentId == id);
        }
        public Shipment? GetByBuyer(string buyer)
        {
            return data1.FirstOrDefault(a => a.Buyer == buyer);
        }
        public bool BuyerExists(string buyer)
        {
            return data1.Any(a => a.Buyer == buyer);
        }
        public void Update(Shipment shipment)
        {

            var existingInfo = data1.FirstOrDefault(x => x.ShipmentId == shipment.ShipmentId);

            if (existingInfo != null)
            {
                existingInfo.Buyer = shipment.Buyer;
                existingInfo.Number = shipment.Number;
                existingInfo.Address = shipment.Address;
            }
        }
        public List<Shipment> GetShipment()
        {
            return data1;
        }
        public List<Details> GetDetails()
        {
            return data2;
        }
    }
}