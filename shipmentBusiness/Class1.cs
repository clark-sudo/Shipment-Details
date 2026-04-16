using shipmentData;
using shipmentModel;

namespace shipmentBusiness
{
    public class Compare
    {
        savedData data1 = new savedData(new savedDataInMemory());
        shipmentJsonData jsonData = new shipmentJsonData();

        public void Add(Guid ShipmentId, int addQuantity)
        {
            var quantity = data1.GetShipment();
            var updQuantity = quantity.FirstOrDefault(t => t.ShipmentId == ShipmentId);
            int totalQuantity = updQuantity.Quantity + addQuantity;
            if (updQuantity != null)
            {
                updQuantity.Quantity = totalQuantity;
                data1.Update(updQuantity);
                jsonData.Update(updQuantity);
            }
        }

        //public string check()
        //{
        //    savedData data = new savedData();
        //    switch (data.getMonth())
        //    {
        //        case 1:
        //            Console.Write("January ");
        //            break;
        //        case 2:
        //            Console.Write("February ");
        //            break;
        //        case 3:
        //            Console.Write("March ");
        //            break;
        //        case 4:
        //            Console.Write("April ");
        //            break;
        //        case 5:
        //            Console.Write("May ");
        //            break;
        //        case 6:
        //            Console.Write("June ");
        //            break;
        //        case 7:
        //            Console.Write("July ");
        //            break;
        //        case 8:
        //            Console.Write("August ");
        //            break;
        //        case 9:
        //            Console.Write("September ");
        //            break;
        //        case 10:
        //            Console.Write("October ");
        //            break;
        //        case 11:
        //            Console.Write("November ");
        //            break;
        //        case 12:
        //            Console.Write("December ");
        //            break;
        //    }

        //}

        public int SubTotal()
        {
            int quantity = data1.GetShipment().First().Quantity;
            int price = data1.GetShipment().First().Price;
            int subTotal = price * quantity;
            return subTotal;
        }

        public int Shipping(int fee)
        {
            if (SubTotal() >= 50)
            {
                fee = data1.GetShipment().First().Fee;
            }
            else
            {
                fee = 0;
            }
            return fee;
        }

        public int Total(int fee)
        {
            int shippingFee = Shipping(fee);
            int subTotal = SubTotal() + data1.GetShipment().First().Fee;
            int total = subTotal - shippingFee;
            return total;
        }

        public void Update(Guid ShipmentId, int subQuantity)
        {
            var quantity = data1.GetShipment();
            var updQuantity = quantity.FirstOrDefault(t => t.ShipmentId == ShipmentId);
            if (updQuantity != null)
            {
                updQuantity.Quantity = subQuantity;
                data1.Update(updQuantity);
                jsonData.Update(updQuantity);
            }
        }

        public void Delete(Guid ShipmentId)
        {
            var order = data1.GetShipment();
            var delOrder = order.FirstOrDefault(t => t.ShipmentId == ShipmentId);
            if (delOrder != null)
            {
                order.Remove(delOrder);
                data1.Update(delOrder);
                jsonData.Update(delOrder);
            }
        }

        public bool Authenticate(string buyer, string number, string address)
        {
            var account = data1.GetByBuyer(buyer);

            if (account == null)
                return false;

            return account.Address == address;
        }

        public List<Shipment> GetShipment()
        {
            return data1.GetShipment();

        }
        public Shipment? GetShipment(Guid shipmentId)
        {
            return data1.GetById(shipmentId);
        }
    }
}