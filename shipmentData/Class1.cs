using shipmentModel;

namespace shipmentData
{
    public class savedData
    {
        public List<Shipment> data1 = new List<Shipment>();
        public List<Details> data2 = new List<Details>();
        public savedData()
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
        public void AddShipment(Shipment shipment)
        {
            data1.Add(shipment);
        }
        public List<Shipment> GetShipment()
        {
            return data1;
        }
        public List<Details> GetDetails()
        {
            return data2;
        }

        public int getSub()
        {
            Details details = new Details();
            int price = details.Price;
            int quantity = details.Quantity;
            int sub = price * quantity;
            return sub;
        }
        public int getTotal()
        {
            int total = getSub();
            return total;
        }
    }
}